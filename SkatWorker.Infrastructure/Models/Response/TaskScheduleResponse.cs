namespace SkatWorker.Infrastructure.Models.Response
{
    /// <summary>
    /// Запись расписания задачи.
    /// </summary>
    public class TaskScheduleResponse
    {
        /// <summary>
        /// Идентификатор задачи.
        /// </summary>
        public string WorkflowId { get; set; }

        /// <summary>
        /// Идентификатор запущенной задачи.
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// Версия задачи.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Запланированное время запуска.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Входные параметры задачи.
        /// </summary>
        public object Data { get; set; }
    }
}
