using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services.BackgroundTasks
{
    /// <summary>
    /// Опросчик расписания запуска задач.
    /// </summary>
    internal class RunnableTaskSchedule : IBackgroundTask
    {
        private readonly ILogger<RunnableTaskSchedule> _logger;
        private readonly IPersistenceProvider _persistenceProvider;
        private readonly IWorkflowController _workflowController;
        private Timer _runnableTaskScheduleTimer;
        private static JsonSerializerSettings _serializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public RunnableTaskSchedule(IPersistenceProvider persistenceProvider, IWorkflowController workflowController, ILogger<RunnableTaskSchedule> logger)
        {
            _persistenceProvider = persistenceProvider;
            _workflowController = workflowController;
            _logger = logger;
        }

        public void Start()
        {
            _runnableTaskScheduleTimer = new Timer(new TimerCallback(RunTaskSchedule), null, TimeSpan.FromSeconds(0), TimeSpan.FromMinutes(1));
        }

        public void Stop()
        {
            if (_runnableTaskScheduleTimer != null)
            {
                _runnableTaskScheduleTimer.Dispose();
                _runnableTaskScheduleTimer = null;
            }
        }

        /// <summary>
        /// Запустить опрос расписания.
        /// </summary>
        private async void RunTaskSchedule(object target)
        {
            await RunTaskSchedulePoller();
        }

        /// <summary>
        /// Запустить опросчик распиания задач.
        /// </summary>
        /// <returns></returns>
        private async Task RunTaskSchedulePoller()
        {
            var taskSchedules = await _persistenceProvider.GetTaskSchedules(x => x.StartTime <= DateTime.Now && !x.IsProcessed);

            if (!taskSchedules.Any())
            {
                _logger.LogInformation("Task for start today or earlier not found");
                return;
            }

            foreach (var task in taskSchedules)
            {
                _logger.LogInformation($"Try start workflow {task.WorkflowId}");

                try
                {
                    string startedWf = await _workflowController.StartWorkflow(task.WorkflowId, task.Version, task.Data);
                    WorkflowInstance wfInstance = await _persistenceProvider.GetWorkflowInstance(startedWf);

                    _logger.LogInformation($"Workflow {task.WorkflowId} successful started. Instance id {wfInstance.Id}");
                    await _persistenceProvider.MarkTaskScheduleProcessed(task.Id);
                    
                    return;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Workflow {task.WorkflowId} not started. Exception message {ex.Message}");
                    await _persistenceProvider.MarkTaskScheduleUnprocessed(task.Id);
                    
                    return;
                }
            }
        }
    }
}
