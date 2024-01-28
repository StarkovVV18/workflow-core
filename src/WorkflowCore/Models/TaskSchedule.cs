using System;

namespace WorkflowCore.Models
{
    public class TaskSchedule
    {
        public string Id { get; set; }

        public string DefinitionId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime CompleteTime { get; set; }

        public bool IsProcessed { get; set; }

        public string Result { get; set; }
    }
}
