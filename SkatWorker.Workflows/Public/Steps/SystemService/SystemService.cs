using Microsoft.Extensions.Logging;
using SkatWorker.Libraries.HttpClient.Builder;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using System.ServiceProcess;
using SkatWorker.Infrastructure.Services.DownloaderService;
using SkatWorker.Application.Interfaces.Downloader;

namespace SkatWorker.Workflows.Public.Steps.SystemService
{
    /// <summary>
    /// Шаг для работы со службами Windows.
    /// </summary>
    public class SystemService : StepBody
    {
        static string Name { get => "SystemService"; }

        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<SystemService> _logger;

        private readonly IPersistenceProvider _persistenceProvider;

        /// <summary>
        /// Имя сервиса.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Действие над службой.
        /// </summary>
        public SystemServiceCommand SystemServiceCommand { get; set; }

        /// <summary>
        /// Результат работы.
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Результат состояния.
        /// </summary>
        public ServiceControllerStatus SystemServiceResult { get; set; }

        public SystemService(ILogger<SystemService> logger, IPersistenceProvider persistenceProvider)
        {
            _logger = logger;
            _persistenceProvider = persistenceProvider;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var services = ServiceController.GetServices();
            var findedService = services.Where(x => x.ServiceName == ServiceName).FirstOrDefault();

            if (findedService == null)
            {
                string message = $"Service {ServiceName} not found.";
                _persistenceProvider.CreateStepResult(this.CreateStepResult(context, message));

                return ExecutionResult.Outcome(message);
            }

            if (SystemServiceCommand == SystemServiceCommand.Start)
            {
                findedService.Start();
                SystemServiceResult = ServiceControllerStatus.StartPending;
            }

            if (SystemServiceCommand == SystemServiceCommand.Start)
            {
                findedService.Stop();
                SystemServiceResult = ServiceControllerStatus.StopPending;
            }

            if (SystemServiceCommand == SystemServiceCommand.Status)
            {
                var statusService = findedService.Status;
                SystemServiceResult = statusService;
            }

            _persistenceProvider.CreateStepResult(this.CreateStepResult(context));

            return ExecutionResult.Next();
        }

        private StepResult CreateStepResult(IStepExecutionContext context)
        {
            StepResult result = new StepResult();

            // TODO: Добавить вх. параметры.
            result.CompleteTime = DateTime.Now;
            result.InstanceId = context.Workflow.Id;
            result.WorkflowDefinitionId = context.Workflow.WorkflowDefinitionId;
            result.Result = SystemServiceResult.ToString();
            result.Name = Name;

            return result;
        }

        private StepResult CreateStepResult(IStepExecutionContext context, string result)
        {
            StepResult stepResult = new StepResult();

            // TODO: Добавить вх. параметры.
            stepResult.CompleteTime = DateTime.Now;
            stepResult.InstanceId = context.Workflow.Id;
            stepResult.WorkflowDefinitionId = context.Workflow.WorkflowDefinitionId;
            stepResult.Result = result;
            stepResult.Name = Name;

            return stepResult;
        }
    }
}
