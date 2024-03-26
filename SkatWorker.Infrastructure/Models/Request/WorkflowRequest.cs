namespace SkatWorker.Infrastructure.Models.Request
{
    /// <summary>
    /// Класс передачи данных для добавления задачи в расписание.
    /// </summary>
    public class WorkflowRequest
    {
        /// <summary>
        /// Идентификатор рабочего процесса.
        /// </summary>
        public string WorkflowId { get; set; }
    }
}
