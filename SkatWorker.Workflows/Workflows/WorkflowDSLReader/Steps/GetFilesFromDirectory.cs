using Microsoft.Extensions.Logging;
using SkatWorker.Application.Interfaces;
using SkatWorker.Application.Interfaces.Models;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SkatWorker.Workflows.WorkflowDSLReader.Steps
{
    /// <summary>
    /// Шаг для получения файлов из директории.
    /// </summary>
    public class GetFilesFromDirectory : StepBody
    {
        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<GetFilesFromDirectory> _logger;

        /// <summary>
        /// Путь до директории.
        /// </summary>
        public string PathToFolder { get; set; }

        /// <summary>
        /// Список файлов директории.
        /// </summary>
        public string[] Files { get; set; }

        /// <summary>
        /// Список определений.
        /// </summary>
        public IEnumerable<PostDefinitionModel> Definitions { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Логер.</param>
        public GetFilesFromDirectory(ILogger<GetFilesFromDirectory> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Выполнение шага.
        /// </summary>
        /// <param name="context">Контекст.</param>
        /// <returns>Результат выполнения шага.</returns>
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            string[] files = null;

            _logger.LogInformation(string.Format("GetFilesFromDirectory. Start read files from {0}", PathToFolder));

            if (string.IsNullOrEmpty(PathToFolder) || !Directory.Exists(PathToFolder))
            {
                _logger.LogInformation(string.Format("GetFilesFromDirectory. Path {0} not found or empty", PathToFolder));

                return ExecutionResult.Outcome("Path not found or empty");
            }

            files = Directory.GetFiles(PathToFolder);

            if (files.Count() <= 0)
            {
                _logger.LogInformation(string.Format("GetFilesFromDirectory. Files not found from {0}", PathToFolder));

                return ExecutionResult.Outcome("Files not found");
            }

            Files = files;

            return ExecutionResult.Next();
        }
    }
}
