using System.Dynamic;

namespace SkatWorker.Domain.Interfaces
{
    /// <summary>
    /// Сервис для работы с Workflow.
    /// </summary>
    public interface IWorkflowService
    {
        /// <summary>
        /// Запустить рабочий процесс.
        /// </summary>
        /// <param name="workflowId">Идентификатор рабочего процесса.</param>
        /// <param name="parameters">Параметры запуска рабочего процесса.</param>
        int StartWorkflow(string workflowId, string parameters);
    }
}
