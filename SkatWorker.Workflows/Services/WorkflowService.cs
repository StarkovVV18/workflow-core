using SkatWorker.Domain.Interfaces;
using System.Dynamic;
using WorkflowCore.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Logging;

namespace SkatWorker.Workflows.Services
{
    public class WorkflowService : IWorkflowService
    {
        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<WorkflowService> _logger;


        /// <summary>
        /// Хост workflow.
        /// </summary>
        private readonly IWorkflowHost _workflowHost;

        public WorkflowService(ILogger<WorkflowService> logger, IWorkflowHost workflowHost)
        {
            _logger = logger;
            _workflowHost = workflowHost;
        }

        public int StartWorkflow(string workflowId, string parameters)
        {
            if (string.IsNullOrEmpty(workflowId))
            {
                _logger.LogInformation(string.Format("StartWorkflow. Workflow with Id {0} is empty", workflowId));
                return 1;
            }

            if (string.IsNullOrEmpty(parameters))
            {
                _logger.LogInformation(string.Format("StartWorkflow. Parameters for workflow with Id {0} is empty", workflowId));
                return 1;
            }

            var expConverter = new ExpandoObjectConverter();
            dynamic convertedParameters = JsonConvert.DeserializeObject<ExpandoObject>(parameters, expConverter);

            _workflowHost.StartWorkflow(workflowId, convertedParameters);

            return 0;
        }
    }
}
