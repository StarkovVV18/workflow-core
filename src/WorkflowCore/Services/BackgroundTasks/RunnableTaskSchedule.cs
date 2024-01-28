using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;

namespace WorkflowCore.Services.BackgroundTasks
{
    internal class RunnableTaskSchedule : IBackgroundTask
    {
        private readonly ILogger<RunnableTaskSchedule> _logger;
        private readonly IPersistenceProvider _persistenceProvider;
        private readonly IWorkflowController _workflowController;

        public RunnableTaskSchedule(IPersistenceProvider persistenceProvider, IWorkflowController workflowController, ILogger<RunnableTaskSchedule> logger)
        {
            _persistenceProvider = persistenceProvider;
            _workflowController = workflowController;
            _logger = logger;
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
