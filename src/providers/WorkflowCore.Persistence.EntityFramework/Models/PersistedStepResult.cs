using System;

namespace WorkflowCore.Persistence.EntityFramework.Models
{
    public class PersistedStepResult
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string WorkflowId { get; set; }

        public string InstanceId { get; set; }

        public int Version { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? CompleteTime { get; set; }

        public bool IsProcessed { get; set; }

        public string Data { get; set; }

        public string Result { get; set; }
    }
}
