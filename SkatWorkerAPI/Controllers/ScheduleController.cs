using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkatWorker.Infrastructure.Models.Request;
using SkatWorker.Infrastructure.Models.Response;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace SkatWorkerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IPersistenceProvider _persistenceProvider;
        private readonly IWorkflowRegistry _workflowRegistry;
        private readonly IMapper _mapper;

        public ScheduleController(IPersistenceProvider persistenceProvider, IWorkflowRegistry workflowRegistry, IMapper mapper)
        {
            _persistenceProvider = persistenceProvider;
            _workflowRegistry = workflowRegistry;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавление задачи в расписание.
        /// </summary>
        /// <returns>Добавленную в расписание задачу.</returns>
        [ProducesResponseType(typeof(TaskScheduleResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponse), 404)]
        [HttpPost("create")]
        public async Task<ActionResult<TaskScheduleResponse>> CreateSchedule([FromBody] TaskSheduleRequest param)
        {
            var definition = _workflowRegistry.GetDefinition(param.WorkflowId);

            if (definition == null)
                return NotFound(new NotFoundResponse(string.Format("Не удалось найти задачу с идентификатором {0}",param.WorkflowId)));

            var dataTypeInstance = JsonConvert.DeserializeObject(param.Data, definition.DataType);
            var taskSchedule = _mapper.Map<TaskSchedule>(param);
            var result = await _persistenceProvider.CreateTaskSchedule(taskSchedule);

            return Ok(_mapper.Map<TaskScheduleResponse>(result));
        }
    }
}
