namespace SkatWorker.Infrastructure.Models.Response
{
    /// <summary>
    /// Результат выполнения шага.
    /// </summary>
    public class StepResultResponse
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Имя шага.
        /// </summary>
        public string Name { get; set; }

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
        /// Дата запуска шага.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Дата заверешения выполнения шага.
        /// </summary>
        public DateTime? CompleteTime { get; set; }

        /// <summary>
        /// Статус выполнения шага.
        /// </summary>
        public bool IsProcessed { get; set; }

        /// <summary>
        /// Входные параметры шага.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Результата выполнения шага.
        /// </summary>
        public string Result { get; set; }
    }
}
