using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Services.DefinitionStorage;

namespace SkatWorker.Workflows.WorkflowDSLReader.Steps
{
    /// <summary>
    /// Шаг для загрузки DSL.
    /// </summary>
    public class LoadWorkflow : StepBody
    {
        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<LoadWorkflow> _logger;

        /// <summary>
        /// Загрузчик WorkflowDSL.
        /// </summary>
        private readonly IDefinitionLoader _loader;

        /// <summary>
        /// Список файлов директории.
        /// </summary>
        public string[] Files { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Логер.</param>
        public LoadWorkflow(ILogger<LoadWorkflow> logger, IDefinitionLoader loader)
        {
            _logger = logger;
            _loader = loader;
        }

        /// <summary>
        /// Выполнение шага.
        /// </summary>
        /// <param name="context">Контекст.</param>
        /// <returns>Результат выполнения шага.</returns>
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            _logger.LogInformation("LoadWorkflow. Start.");

            if (Files == null || Files.Count() <= 0)
            {
                _logger.LogInformation("LoadWorkflow. List of files is empty");
                
                return ExecutionResult.Outcome("Files not found");
            }

            var type = Deserializers.Json;

            foreach (var file in Files)
            {
                _logger.LogInformation(string.Format("LoadWorkflow. Get data from file {0}", Path.GetFileName(file)));

                //var fileName = Path.GetFileNameWithoutExtension(file);
                var data = File.ReadAllText(file);

                _logger.LogInformation("LoadWorkflow. Load definition");

                _loader.LoadDefinition(data, type);
            }

            return ExecutionResult.Next();
        }
    }
}
