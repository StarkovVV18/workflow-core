namespace SkatWorker.Infrastructure.Models.Params
{
    /// <summary>
    /// Класс передачи данных для добавления задачи в расписание.
    /// </summary>
    public class WorkflowParam
    {
        /// <summary>
        /// Идентификатор рабочего процесса.
        /// </summary>
        public string WorkflowId { get; set; }
    }
}
