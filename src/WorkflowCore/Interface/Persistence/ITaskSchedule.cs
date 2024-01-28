﻿using System.Threading.Tasks;
using System.Threading;
using WorkflowCore.Models;

namespace WorkflowCore.Interface.Persistence
{
    public interface ITaskSchedule
    {
        Task<TaskSchedule> CreateTaskSchedule(TaskSchedule taskSchedule, CancellationToken cancellationToken = default);

        Task<TaskSchedule> GetTaskSchedule (string id, CancellationToken cancellationToken = default);

        Task MarkTaskScheduleProcessed(string id, CancellationToken cancellationToken = default);

        Task MarkTaskScheduleUnprocessed(string id, CancellationToken cancellationToken = default);
    }
}
