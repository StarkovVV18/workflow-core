using Microsoft.Extensions.Logging;
using SkatWorker.Application.Interfaces.Downloader;
using SkatWorker.Infrastructure.Services.DownloaderService;
using SkatWorker.Libraries.HttpClient.Builder;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SkatWorker.Workflows.Public.Steps.HttpDownloader
{
    /// <summary>
    /// Шаг для скачивания файла по http.
    /// </summary>
    public class HttpDownloader : StepBody
    {
        static string Name { get => "HttpDownloader"; }

        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<HttpDownloader> _logger;

        private readonly DownloaderService _downloaderService;

        private readonly IPersistenceProvider _persistenceProvider;

        /// <summary>
        /// Токен.
        /// </summary>
        public string Token { get; set; }

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

        /// <summary>
        /// Тип запроса.
        /// </summary>
        public Libraries.HttpClient.Enums.HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// Способ аутентификации.
        /// </summary>
        public Libraries.HttpClient.Enums.AuthenticationScheme AuthenticationScheme { get; set; }

        public HttpDownloader(ILogger<HttpDownloader> logger, DownloaderService downloaderService, IPersistenceProvider persistenceProvider)
        {
            _logger = logger;
            _downloaderService = downloaderService;
            _persistenceProvider = persistenceProvider;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var httpDownloader = new SkatWorker.Infrastructure.Services.DownloaderService.Downloader.HttpDownloader(HttpMethod, AuthenticationScheme);
            var requestData = new RequestData();

            requestData.Login = Login;
            requestData.Password = Password;
            requestData.Host = Host;
            requestData.FileName = FileName;
            requestData.Token = Token;
            requestData.SavePath = SavedFile;

            _downloaderService.SetDowloader(httpDownloader);
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
