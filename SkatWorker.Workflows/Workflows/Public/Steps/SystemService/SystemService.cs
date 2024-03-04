using Microsoft.Extensions.Logging;
using SkatWorker.Infrastructure.Factory.ConnectionMethod.Http;
using SkatWorker.Libraries.HttpClient.Builder;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using System.ServiceProcess;
using SkatWorker.Workflows.Workflows.Public.Steps.SystemService;

namespace SkatWorker.Workflows.Public.Steps.SystemService
{
    /// <summary>
    /// Шаг для работы со службами Windows.
    /// </summary>
    public class SystemService : StepBody
    {
        /// <summary>
        /// Логер.
        /// </summary>
        private readonly ILogger<SystemService> _logger;

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

        public SystemService(ILogger<SystemService> logger)
        {
            _logger = logger;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var services = ServiceController.GetServices();
            var findedService = services.Where(x => x.ServiceName == ServiceName).FirstOrDefault();

            if (findedService == null)
                return ExecutionResult.Outcome($"Service {ServiceName} not found.");

            if (SystemServiceCommand == SystemServiceCommand.Start)
            {
                findedService.Start();
                SystemServiceResult = ServiceControllerStatus.StartPending;

                return ExecutionResult.Next();
            }

            if (SystemServiceCommand == SystemServiceCommand.Start)
            {
                findedService.Stop();
                SystemServiceResult = ServiceControllerStatus.StopPending;

                return ExecutionResult.Next();
            }

            if (SystemServiceCommand == SystemServiceCommand.Status)
            {
                var statusService = findedService.Status;
                SystemServiceResult = statusService;

                return ExecutionResult.Next();
            }

            return ExecutionResult.Next();
        }
    }
}
