namespace SkatWorker.Infrastructure.Models.Request
{
    /// <summary>
    /// Класс передачи данных для добавления задачи в расписание.
    /// </summary>
    public class TaskSheduleRequest
    {
        /// <summary>
        /// Идентификатор задачи.
        /// </summary>
        public string WorkflowId { get; set; }
        
        /// <summary>
        /// Версия задачи.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Дата / время запуска.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Входные параметры задачи.
        /// </summary>
        public string Data { get; set; }
    }
}
