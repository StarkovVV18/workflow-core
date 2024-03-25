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
using SkatWorker.Infrastructure.Models.Params;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkflowInstance>> Get(string id)
        {
            var result = await _persistenceProvider.GetWorkflowInstance(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("start")]
        public async Task<ActionResult<SkatWorker.Infrastructure.Models.ReturnModels.StartedWorkflowInstance>> Post([FromBody] WorkflowStartParam param)
        {
            var definition = _workflowRegistry.GetDefinition(param.WorkflowId);
            var dataTypeInstance = JsonConvert.DeserializeObject(param.Data, definition.DataType);
            var workflowId = await _workflowController.StartWorkflow(param.WorkflowId, dataTypeInstance);
            var startedWorkflow = await _persistenceProvider.GetWorkflowInstance(workflowId);

            return Ok(_mapper.Map<SkatWorker.Infrastructure.Models.ReturnModels.StartedWorkflowInstance>(startedWorkflow));
        }

        [HttpPut("suspend")]
        public async Task Suspend([FromBody] WorkflowParam param)
        {
            var result = await _workflowController.SuspendWorkflow(param.WorkflowId);

            if (result)
                Response.StatusCode = 200;
            else
                Response.StatusCode = 400;
        }

        [HttpPut("resume")]
        public async Task Resume([FromBody] WorkflowParam param)
        {
            var result = await _workflowController.ResumeWorkflow(param.WorkflowId);

            if (result)
                Response.StatusCode = 200;
            else
                Response.StatusCode = 400;
        }

        [HttpDelete("terminate")]
        public async Task Terminate([FromBody] WorkflowParam param)
        {
            var result = await _workflowController.TerminateWorkflow(param.WorkflowId);

            if (result)
                Response.StatusCode = 200;
            else
                Response.StatusCode = 400;
        }
    }
}
