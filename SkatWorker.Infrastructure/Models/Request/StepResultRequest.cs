namespace SkatWorker.Infrastructure.Models.Request
{
    /// <summary>
    /// Запрос результата выполнения шага.
    /// </summary>
    public class StepResultRequest
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
    }
}
