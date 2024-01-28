using System.Threading.Tasks;
using System.Threading;
using WorkflowCore.Models;
using System.Collections.Generic;

namespace WorkflowCore.Interface.Persistence
{
    public interface ITaskScheduleRepository
    {
        Task<TaskSchedule> CreateTaskSchedule(TaskSchedule taskSchedule, CancellationToken cancellationToken = default);

        Task<TaskSchedule> GetTaskSchedule (string id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TaskSchedule>> GetTaskSchedules(CancellationToken cancellationToken = default);

        Task MarkTaskScheduleProcessed(string id, CancellationToken cancellationToken = default);

        Task MarkTaskScheduleUnprocessed(string id, CancellationToken cancellationToken = default);
    }
}
