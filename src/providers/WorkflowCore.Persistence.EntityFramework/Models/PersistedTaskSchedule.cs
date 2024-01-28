using System;
using System.ComponentModel.DataAnnotations;

namespace WorkflowCore.Persistence.EntityFramework.Models
{
    public class PersistedTaskSchedule
    {
        [Key]
        public string Id { get; set; }

        public string DefinitionId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime CompleteTime { get; set; }

        public bool IsProcessed { get; set; }

        public string Result { get; set; }
    }
}
