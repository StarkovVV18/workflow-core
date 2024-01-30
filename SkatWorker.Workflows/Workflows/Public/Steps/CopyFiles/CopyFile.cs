using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SkatWorker.Workflows.Public.Steps.CopyFiles
{
    /// <summary>
    /// Шаг для копирования файла.
    /// </summary>
    public class CopyFile : StepBody
    {
        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<CopyFile> _logger;

        /// <summary>
        /// Источник.
        /// </summary>
        public string SourcePath { get; set; }

        /// <summary>
        /// Назначение.
        /// </summary>
        public string DestinationPath { get; set; }

        public CopyFile(ILogger<CopyFile> logger)
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
