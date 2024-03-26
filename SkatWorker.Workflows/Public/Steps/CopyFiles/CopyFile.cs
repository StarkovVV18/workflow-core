using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SkatWorker.Workflows.Public.Steps.CopyFiles
{
    /// <summary>
    /// Шаг для копирования файла.
    /// </summary>
    public class CopyFile : StepBody
    {
        public string Name { get => "CopyFile"; }

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

        /// <summary>
        /// Результат выполнения шага.
        /// </summary>
        public string Result { get; set; }

        private readonly IPersistenceProvider _persistenceProvider;

        public CopyFile(ILogger<CopyFile> logger, IPersistenceProvider persistenceProvider)
        {
            _logger = logger;
            _persistenceProvider = persistenceProvider;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Result = Boolean.FalseString;

            if (string.IsNullOrEmpty(SourcePath) || !File.Exists(SourcePath))
            {
                _logger.LogInformation(string.Format("CopyFile. Source file {0} not found or empty", SourcePath));

                return ExecutionResult.Outcome("Source file not found or empty");
            }

            _logger.LogInformation(string.Format("CopyFile. File copy from {0} to {1}", SourcePath, DestinationPath));

            string destinationFullPath = Path.Combine(DestinationPath, Path.GetFileName(SourcePath));

            File.Copy(SourcePath, destinationFullPath, true);

            if (File.Exists(destinationFullPath))
                Result = Boolean.TrueString;

            _persistenceProvider.CreateStepResult(this.CreateStepResult(context));

            return ExecutionResult.Next();
        }

        private StepResult CreateStepResult(IStepExecutionContext context)
        {
            StepResult result = new StepResult();

            // TODO: Добавить вх. параметры.
            result.CompleteTime = DateTime.Now;
            result.InstanceId = context.Workflow.Id;
            result.WorkflowId = context.Workflow.WorkflowDefinitionId;
            result.Result = Result;
            result.Name = Name;
            result.Version = context.Workflow.Version;

            return result;
        }
    }
}
