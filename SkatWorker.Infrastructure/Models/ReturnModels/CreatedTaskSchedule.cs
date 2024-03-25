namespace SkatWorker.Infrastructure.Models.ReturnModels
{
    public class CreatedTaskSchedule
    {
        public string WorkflowId { get; set; }

        public string InstanceId { get; set; }

        public int Version { get; set; }

        public DateTime StartTime { get; set; }

        public object Data { get; set; }
    }
}
