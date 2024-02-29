using Microsoft.Extensions.Logging;
using SkatWorker.Application.Models;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Services.DefinitionStorage;

namespace SkatWorker.Workflows.WorkflowDSLReader.Steps
{
    /// <summary>
    /// Шаг для загрузки DSL.
    /// </summary>
    public class LoadWorkflowWeb : StepBody
    {
        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<LoadWorkflowWeb> _logger;

        /// <summary>
        /// Загрузчик WorkflowDSL.
        /// </summary>
        private readonly IDefinitionLoader _loader;

        /// <summary>
        /// Список определений.
        /// </summary>
        public IEnumerable<PostDefinitionModel> Definitions { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Логер.</param>
        public LoadWorkflowWeb(ILogger<LoadWorkflowWeb> logger, IDefinitionLoader loader)
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
            _logger.LogInformation("LoadWorkflowWeb. Start.");

            var type = Deserializers.Json;

            foreach (var definition in Definitions)
            {
                byte[] decodedBytes = Convert.FromBase64String(definition.Value);
                string decodedDefinition = System.Text.Encoding.Default.GetString(decodedBytes);

                _logger.LogInformation(string.Format("LoadWorkflow. Load and registry definition {0}", definition.WorkflowId));

                _loader.LoadDefinition(decodedDefinition, type);
            }

            return ExecutionResult.Next();
        }
    }
}
