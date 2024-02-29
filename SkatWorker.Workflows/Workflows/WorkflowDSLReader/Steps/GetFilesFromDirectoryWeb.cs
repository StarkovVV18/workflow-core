using Microsoft.Extensions.Logging;
using SkatWorker.Application.Interfaces.Models;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SkatWorker.Workflows.WorkflowDSLReader.Steps
{
    /// <summary>
    /// Шаг для получения файлов из директории.
    /// </summary>
    public class GetFilesFromDirectoryWeb : StepBody
    {
        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<GetFilesFromDirectoryWeb> _logger;

        /// <summary>
        /// Список файлов директории.
        /// </summary>
        public string[] Files { get; set; }

        /// <summary>
        /// Список определений.
        /// </summary>
        public IEnumerable<IDefinitionModel> Definitions { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Логер.</param>
        public GetFilesFromDirectoryWeb(ILogger<GetFilesFromDirectoryWeb> logger)
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

            foreach (var definition in Definitions)
            {
                byte[] decodedBytes = Convert.FromBase64String(definition.Value);
                string decodedDefinition = System.Text.Encoding.Default.GetString(decodedBytes);

                if (files == null)
                    files = new string[Definitions.Count()];

                files.Append(decodedDefinition);
            }

            Files = files;

            return ExecutionResult.Next();
        }
    }
}
