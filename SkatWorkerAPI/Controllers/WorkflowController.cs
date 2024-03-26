using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using SkatWorker.Workflows.Public.Steps.CopyFiles.Parameters;
using System.Text.Json.Serialization;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AutoMapper;
using SkatWorker.Infrastructure.Models.Request;
using SkatWorker.Infrastructure.Models.Response;

namespace SkatWorkerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowController _workflowController;
        private readonly IPersistenceProvider _persistenceProvider;
        private readonly IWorkflowRegistry _workflowRegistry;
        private readonly IMapper _mapper;

        public WorkflowController(IWorkflowController workflowController, IPersistenceProvider persistenceProvider, IWorkflowRegistry workflowRegistry, IMapper mapper)
        {
            _workflowController = workflowController;
            _persistenceProvider = persistenceProvider;
            _workflowRegistry = workflowRegistry;
            _mapper = mapper;
        }

        /// <summary>
        /// Найти задачу по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор задачи.</param>
        /// <returns>Запущенный экземпляр задачи.</returns>
        [ProducesResponseType(typeof(WorkflowInstance), 200)]
        [ProducesResponseType(typeof(NotFoundResponse), 404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkflowInstance>> Get(string id)
        {
            var result = await _persistenceProvider.GetWorkflowInstance(id);

            if (result == null)
                return NotFound(new NotFoundResponse(string.Format("Не удалось найти запущенную задачу с идентификатором {0}", id)));

            return Ok(result);
        }

        /// <summary>
        /// Запустить задачу.
        /// </summary>
        /// <param name="param">Параметры запуска задачи.</param>
        /// <returns>Запущенная задача.</returns>
        [ProducesResponseType(typeof(WorkflowInstanceResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponse), 404)]
        [HttpPost("start")]
        public async Task<ActionResult<WorkflowInstanceResponse>> Post([FromBody] WorkflowStartRequest param)
        {
            var definition = _workflowRegistry.GetDefinition(param.WorkflowId);

            if (definition == null)
                return NotFound(new NotFoundResponse(string.Format("Не удалось найти задачу с идентификатором {0}", param.WorkflowId)));

            var dataTypeInstance = JsonConvert.DeserializeObject(param.Data, definition.DataType);
            var workflowId = await _workflowController.StartWorkflow(param.WorkflowId, dataTypeInstance);
            var startedWorkflow = await _persistenceProvider.GetWorkflowInstance(workflowId);

            return Ok(_mapper.Map<WorkflowInstanceResponse>(startedWorkflow));
        }

        /// <summary>
        /// Приостановить выполнение задачи.
        /// </summary>
        /// <param name="param">Параметры запроса.</param>
        [HttpPut("suspend")]
        public async Task Suspend([FromBody] WorkflowRequest param)
        {
            var result = await _workflowController.SuspendWorkflow(param.WorkflowId);

            if (result)
                Response.StatusCode = 200;
            else
                Response.StatusCode = 400;
        }

        /// <summary>
        /// Возобновить выполнение задачи.
        /// </summary>
        /// <param name="param">Параметры запроса.</param>
        [HttpPut("resume")]
        public async Task Resume([FromBody] WorkflowRequest param)
        {
            var result = await _workflowController.ResumeWorkflow(param.WorkflowId);

            if (result)
                Response.StatusCode = 200;
            else
                Response.StatusCode = 400;
        }

        /// <summary>
        /// Остановить выполнение задачи.
        /// </summary>
        /// <param name="param">Параметры запроса.</param>
        [HttpDelete("terminate")]
        public async Task Terminate([FromBody] WorkflowRequest param)
        {
            var result = await _workflowController.TerminateWorkflow(param.WorkflowId);

            if (result)
                Response.StatusCode = 200;
            else
                Response.StatusCode = 400;
        }
    }
}
