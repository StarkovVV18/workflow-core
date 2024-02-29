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

using WorkflowCore.Interface;
using SkatWorker.Workflows.Services;
using SkatWorker.Workflows.WorkflowDSLReader.Steps;
using SkatWorker.Workflows.WorkflowDSLReader.Inputs;
using SkatWorker.Workflows.WorkflowDSLReader;
using SkatWorker.Workflows.Public.Steps.CopyFiles;
using System.IO;
using SkatWorker.Application.Interfaces.Services;

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
            services.AddLogging();

            services.AddControllers();

            // Подключаем свагер.
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

            // Получение пути C:\Users\<User>\AppData\Roaming\
            string applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string skatWorkerFullPath = Path.Combine(applicationDataPath, "SkatWorker");
            string fullPathToDb = Path.Combine(skatWorkerFullPath, "wfdb.db");

            // Сервисы workflow.
            services.AddWorkflow(wf => wf.UseSqlite(string.Format("Data Source={0};", fullPathToDb), true));
            services.AddWorkflowDSL();

            // Шаги для базовых рабочих процессов.
            services.AddTransient<GetFilesFromDirectory>();
            services.AddTransient<LoadWorkflow>();
            services.AddTransient<GetFilesFromDirectoryWeb>();
            services.AddTransient<LoadWorkflowWeb>();

            // Публичные шаги.
            services.AddTransient<CopyFile>();

            // Внутренние сервисы.
            services.AddTransient<IDefinitionService, DefinitionService>();
            services.AddTransient<IWorkflowService, WorkflowService>();
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

            // Запускает хост workflow.
            var wfHost = app.ApplicationServices.GetService<IWorkflowHost>();

            // Регистрируем базовые рабочие процессы.
            wfHost.RegisterWorkflow<WorkflowDSLReaderPath, FilesFromDirectory>();
            wfHost.RegisterWorkflow<WorkflowDSLReaderWeb, FilesFromDirectory>();

            wfHost.Start();
        }
    }
}
