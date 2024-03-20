using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;
using SkatWorkerAPI.Models.Params;

namespace SkatWorkerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IPersistenceProvider _persistenceProvider;

        public ScheduleController(IPersistenceProvider persistenceProvider)
        {
            _persistenceProvider = persistenceProvider;
        }

        /// <summary>
        /// Добавить задачу в расписание.
        /// </summary>
        /// <param name="data">Входные параметры рабочего процесса.</param>
        /// <returns>Идентификатор расписания.</returns>
        /// [ProducesResponseType(typeof(TaskSheduleParam), 204)]
        /// [ProducesResponseType(typeof(CopyFileParam), 204)]
        [HttpPost("create")]
        public async Task CreateSchedule([FromBody] TaskSheduleParam data)
        {
            var taskSchedule = new TaskSchedule { WorkflowId = data.WorkflowId, Version = data.Version, StartTime = data.StartTime, Data = data.Data };
            var result = await _persistenceProvider.CreateTaskSchedule(taskSchedule);

            Response.StatusCode = 200;
        }
    }
}
