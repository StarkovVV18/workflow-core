using SkatWorker.Workflows.Public.Steps.CopyFiles.Parameters;
using System;

namespace SkatWorkerAPI.Models.Params
{
    /// <summary>
    /// Класс передачи данных для добавления задачи в расписание.
    /// </summary>
    public class TaskSheduleParam
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
        /// Дата / время запуска.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Входные параметры рабочего процесса.
        /// </summary>
        public CopyFileParam Data { get; set; }
    }
}
