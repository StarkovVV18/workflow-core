using System;
using System.ComponentModel.DataAnnotations;

namespace WorkflowCore.Persistence.EntityFramework.Models
{
    public class PersistedTaskSchedule
    {
        [Key]
        public string Id { get; set; }

        public string WorkflowId { get; set; }

        [MaxLength(200)]
        public string InstanceId { get; set; }

        public int Version { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? CompleteTime { get; set; }

        public bool IsProcessed { get; set; }

        public string Data { get; set; }

        public string Result { get; set; }
    }
}
