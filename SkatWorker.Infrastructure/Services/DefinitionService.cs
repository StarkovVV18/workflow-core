//using SkatWorker.Workflows.WorkflowDSLReader;
//using SkatWorker.Workflows.WorkflowDSLReader.Inputs;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Services.DefinitionStorage;
using Microsoft.Extensions.Logging;
using SkatWorker.Application.Interfaces.Services;
using SkatWorker.Application.Interfaces.Models;

namespace SkatWorker.Infrastructure.Services
{
    public class DefinitionService : IDefinitionService
    {
        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<DefinitionService> _logger;

        /// <summary>
        /// Загрузчик WorkflowDSL.
        /// </summary>
        private readonly IDefinitionLoader _loader;

        /// <summary>
        /// Хост workflow.
        /// </summary>
        private readonly IWorkflowHost _workflowHost;

        public DefinitionService(ILogger<DefinitionService> logger, IDefinitionLoader loader, IWorkflowHost workflowHost)
        {
            _logger = logger;
            _loader = loader;
            _workflowHost = workflowHost;
        }

        public string GetDefinition(string id)
        {
            throw new NotImplementedException();
        }

        public void LoadDefinitionsFromStorage()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkflowDefinition> RegisterNewDefinition(string pathDefinition)
        {
            if (string.IsNullOrEmpty(pathDefinition) || !Directory.Exists(pathDefinition))
            {
                _logger.LogInformation(string.Format("RegisterNewDefinition. Path {0} not found or empty", pathDefinition));
                return null;
            }

            IEnumerable<WorkflowDefinition> result = new List<WorkflowDefinition>();
            string[] files = null;

            files = Directory.GetFiles(pathDefinition);

            if (files.Count() <= 0)
                _logger.LogInformation(string.Format("GetFilesFromDirectory. Files not found from {0}", pathDefinition));

            _logger.LogInformation("LoadWorkflow. Start.");

            if (files == null || files.Count() <= 0)
                _logger.LogInformation("LoadWorkflow. List of files is empty");

            var type = Deserializers.Json;

            foreach (var file in files)
            {
                _logger.LogInformation(string.Format("LoadWorkflow. Get data from file {0}", Path.GetFileName(file)));

                var fileName = Path.GetFileNameWithoutExtension(file);
                var data = File.ReadAllText(file);

                _logger.LogInformation(string.Format("LoadWorkflow. Load and registry definition {0}", fileName));

                result.Append(_loader.LoadDefinition(data, type));
            }

            return result;
        }

        public WorkflowDefinition RegisterNewDefinition(IEnumerable<IDefinitionModel> datasets)
        {
            var type = Deserializers.Json;
            WorkflowDefinition result = null;

            foreach (var definition in datasets)
            {
                byte[] decodedBytes = Convert.FromBase64String(definition.Value);
                string decodedDefinition = System.Text.Encoding.Default.GetString(decodedBytes);

                _logger.LogInformation(string.Format("LoadWorkflow. Load and registry definition {0}", definition.WorkflowId));

                result = _loader.LoadDefinition(decodedDefinition, type);
            }

            return result;
        }

        public void ReplaceVersion(string definition)
        {
            throw new NotImplementedException();
        }
    }
}
