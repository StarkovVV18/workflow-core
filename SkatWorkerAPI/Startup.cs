using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using WorkflowCore.Interface;
using SkatWorker.Infrastructure.Services;
using SkatWorker.Workflows.WorkflowDSLReader.Steps;
using SkatWorker.Workflows.WorkflowDSLReader.Inputs;
using SkatWorker.Workflows.WorkflowDSLReader;
using SkatWorker.Workflows.Public.Steps.CopyFiles;
using SkatWorker.Application.Interfaces.Services;
using SkatWorker.Infrastructure.Services.DownloaderService;
using SkatWorker.Workflows.Public.Steps.HttpDownloader;
using SkatWorker.Workflows.Public.Steps.FtpDownloader;
using SkatWorker.Workflows.Workflows.CopyFiles;
using SkatWorker.Workflows.Public.Steps.CopyFiles.Parameters;
using SkatWorker.Workflows.Public.Steps.HttpDownloader.Inputs;
using SkatWorker.Workflows.Public.Steps.FtpDownloader.Inputs;
using SkatWorker.Workflows.Public.Steps.SystemService.Inputs;
using SkatWorker.Workflows.Public.Steps.SystemService;

using AutoMapper;
using Serilog;

namespace SkatWorkerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSerilog(x =>
            {
                x.WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFiles", $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} Log.txt"));
            });

            services.AddControllers();

            // ���������� ������.
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SkatWorkerAPI"
                });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "SkatWorkerAPI.xml");
                swagger.IncludeXmlComments(filePath);
            });

            // ��������� ���� C:\Users\<User>\AppData\Roaming\
            string applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string skatWorkerFullPath = Path.Combine(applicationDataPath, "SkatWorker");
            string fullPathToDb = Path.Combine(skatWorkerFullPath, "wfdb.db");

            // ���������� ������
            var mapperConfig = new MapperConfiguration(x => {
                    x.AllowNullCollections = true;
                    x.AddProfile<SkatWorker.Infrastructure.Mapper.SkatWorkerMapper>();
                });

            services.AddSingleton<IMapper>(x => new Mapper(mapperConfig));

            // ������� workflow.
            services.AddWorkflow(wf => wf.UseSqlite(string.Format("Data Source={0};", fullPathToDb), true));
            services.AddWorkflowDSL();

            // ���� ��� ������� ������� ���������.
            services.AddTransient<GetFilesFromDirectory>();
            services.AddTransient<LoadWorkflow>();
            services.AddTransient<GetFilesFromDirectoryWeb>();
            services.AddTransient<LoadWorkflowWeb>();

            // ��������� ����.
            services.AddTransient<SkatWorker.Workflows.Public.Steps.CopyFiles.CopyFile>();
            services.AddTransient<HttpDownloader>();
            services.AddTransient<FtpDownloader>();
            services.AddTransient<SystemService>();

            // ���������� �������.
            services.AddTransient<IDefinitionService, DefinitionService>();
            services.AddTransient<IWorkflowService, WorkflowService>();
            services.AddTransient<DownloaderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // ��������� ���� workflow.
            var wfHost = app.ApplicationServices.GetService<IWorkflowHost>();

            // ������������ ������� ������.
            wfHost.RegisterWorkflow<WorkflowDSLReaderPath, FilesFromDirectory>();
            wfHost.RegisterWorkflow<WorkflowDSLReaderWeb, FilesFromDirectory>();
            wfHost.RegisterWorkflow<SkatWorker.Workflows.Workflows.CopyFiles.CopyFile, CopyFileParam>();
            wfHost.RegisterWorkflow<SkatWorker.Workflows.Workflows.HttpDownloader.HttpDownloader, HttpDownloaderParam>();
            wfHost.RegisterWorkflow<SkatWorker.Workflows.Workflows.FtpDownloader.FtpDownloader, FtpDownloaderParam>();
            wfHost.RegisterWorkflow<SkatWorker.Workflows.Workflows.SystemService.SystemService, SystemServiceParam>();

            wfHost.Start();
        }
    }
}
