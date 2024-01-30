using SkatWorker.Workflows.Public.Steps.CopyFiles.Parameters;
using System;

namespace SkatWorkerAPI.Models
{
    public class TaskSheduleParam
    {
        public string WorkflowId { get; set; }

        public int Version { get; set; }

        public DateTime StartTime { get; set; }

        public CopyFileParam Data { get; set; }
    }
}
