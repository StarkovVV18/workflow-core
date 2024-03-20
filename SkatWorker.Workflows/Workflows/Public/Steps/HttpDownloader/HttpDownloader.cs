using Microsoft.Extensions.Logging;
using SkatWorker.Infrastructure.Factory.ConnectionMethod.Http;
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
        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<HttpDownloader> _logger;

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

        public HttpDownloader(ILogger<HttpDownloader> logger)
        {
            _logger = logger;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var httpConnection = new HttpConnectionMethodFactory().GetConnectionTechnique(HttpMethod);

            httpConnection.Login = Login;
            httpConnection.Password = Password;
            httpConnection.Host = Host;
            httpConnection.FileName = FileName;

            SavedFile = httpConnection.Download();

            return ExecutionResult.Next();
        }
    }
}
