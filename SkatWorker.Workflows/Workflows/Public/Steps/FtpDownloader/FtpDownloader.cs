using Microsoft.Extensions.Logging;
using SkatWorker.Application.Interfaces.Downloader;
using SkatWorker.Infrastructure.Factory.ConnectionMethod.Ftp;
using SkatWorker.Infrastructure.Factory.ConnectionMethod.Http;
using SkatWorker.Infrastructure.Services.DownloaderService;
using SkatWorker.Libraries.HttpClient.Builder;
using SkatWorker.Libraries.HttpClient.Enums;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SkatWorker.Workflows.Public.Steps.FtpDownloader
{
    /// <summary>
    /// Шаг для скачивания файла по ftp.
    /// </summary>
    public class FtpDownloader : StepBody
    {
        static string Name { get => "FtpDownloader"; }

        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<FtpDownloader> _logger;

        private readonly DownloaderService _downloaderService;

        private readonly IPersistenceProvider _persistenceProvider;

        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// URL адрес.
        /// </summary>
        public string Host { get; set; }
        
        /// <summary>
        /// Имя файла с расширением.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Путь до скачанного файла.
        /// </summary>
        public string SavedFile { get; set; }


        public FtpDownloader(ILogger<FtpDownloader> logger, DownloaderService downloaderService, IPersistenceProvider persistenceProvider)
        {
            _logger = logger;
            _downloaderService = downloaderService;
            _persistenceProvider = persistenceProvider;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var ftpDownloader = new SkatWorker.Infrastructure.Services.DownloaderService.Downloader.FtpDownloader();
            var requestData = new RequestData();

            requestData.Login = Login;
            requestData.Password = Password;
            requestData.Host = Host;
            requestData.FileName = FileName;
            requestData.SavePath = SavedFile;

            _downloaderService.SetDowloader(ftpDownloader);
            var downloadResult = _downloaderService.Download();

            _persistenceProvider.CreateStepResult(this.CreateStepResult(context, downloadResult));

            return ExecutionResult.Next();
        }

        private StepResult CreateStepResult(IStepExecutionContext context, IDownloadResult downloadResult)
        {
            StepResult result = new StepResult();

            // TODO: Добавить вх. параметры.
            result.CompleteTime = DateTime.Now;
            result.InstanceId = context.Workflow.Id;
            result.WorkflowDefinitionId = context.Workflow.WorkflowDefinitionId;
            result.Result = downloadResult.Result;
            result.Name = Name;

            return result;
        }
    }
}
