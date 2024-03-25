using SkatWorker.Workflows.Public.Steps.CopyFiles.Parameters;
using System;
using System.Dynamic;

namespace SkatWorkerAPI.Models.Params
{
    /// <summary>
    /// Класс передачи данных для добавления задачи в расписание.
    /// </summary>
    public class WorkflowStartParam
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
