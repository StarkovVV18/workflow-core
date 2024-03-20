using Microsoft.Extensions.Logging;
using SkatWorker.Infrastructure.Factory.ConnectionMethod.Ftp;
using SkatWorker.Infrastructure.Factory.ConnectionMethod.Http;
using SkatWorker.Libraries.HttpClient.Builder;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SkatWorker.Workflows.Public.Steps.FtpDownloader
{
    /// <summary>
    /// Шаг для скачивания файла по ftp.
    /// </summary>
    public class FtpDownloader : StepBody
    {
        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<FtpDownloader> _logger;

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

        public FtpDownloader(ILogger<FtpDownloader> logger)
        {
            _logger = logger;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var ftpConnection = new FtpConnectionMethodFactory().GetConnectionTechnique();

            ftpConnection.Login = Login;
            ftpConnection.Password = Password;
            ftpConnection.Host = Host;
            ftpConnection.FileName = FileName;

            SavedFile = ftpConnection.Download();

            return ExecutionResult.Next();
        }
    }
}
