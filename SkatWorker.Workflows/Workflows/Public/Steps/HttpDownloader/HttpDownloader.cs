using Microsoft.Extensions.Logging;
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
        /// Источник.
        /// </summary>
        public string SourcePath { get; set; }

        /// <summary>
        /// Назначение.
        /// </summary>
        public string DestinationPath { get; set; }

        public HttpDownloader(ILogger<HttpDownloader> logger)
        {
            _logger = logger;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            if (string.IsNullOrEmpty(SourcePath) || !File.Exists(SourcePath))
            {
                _logger.LogInformation(string.Format("CopyFile. Source file {0} not found or empty", SourcePath));

                return ExecutionResult.Outcome("Source file not found or empty");
            }

            _logger.LogInformation(string.Format("CopyFile. File copy from {0} to {1}", SourcePath, DestinationPath));

            string destinationFullPath = Path.Combine(DestinationPath, Path.GetFileName(SourcePath));

            File.Copy(SourcePath, destinationFullPath, true);

            return ExecutionResult.Next();
        }
    }
}
