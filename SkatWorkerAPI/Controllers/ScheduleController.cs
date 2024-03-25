using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkatWorker.Infrastructure.Models.Params;
using SkatWorker.Infrastructure.Models.ReturnModels;
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
        /// Добавить задачу в расписание.
        /// </summary>
        /// <param name="data">Входные параметры рабочего процесса.</param>
        /// <returns>Идентификатор расписания.</returns>
        /// [ProducesResponseType(typeof(TaskSheduleParam), 204)]
        /// [ProducesResponseType(typeof(CopyFileParam), 204)]
        [HttpPost("create")]
        public async Task<ActionResult<CreatedTaskSchedule>> CreateSchedule([FromBody] TaskSheduleParam param)
        {
            var definition = _workflowRegistry.GetDefinition(param.WorkflowId);
            var dataTypeInstance = JsonConvert.DeserializeObject(param.Data, definition.DataType);
            var taskSchedule = _mapper.Map<TaskSchedule>(param);
            var result = await _persistenceProvider.CreateTaskSchedule(taskSchedule);

            return Ok(_mapper.Map<CreatedTaskSchedule>(result));
        }
    }
}
