namespace SkatWorker.Infrastructure.Models.Request
{
    /// <summary>
    /// Класс передачи данных для добавления задачи в расписание.
    /// </summary>
    public class WorkflowStartRequest
    {
        /// <summary>
        /// Идентификатор рабочего процесса.
        /// </summary>
        public string WorkflowId { get; set; }
        
        /// <summary>
        /// Версия запускаемого рабочего процесса.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Входные параметры рабочего процесса.
        /// </summary>
        public string Data { get; set; }
    }
}
