using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Dynamic;
using System.Threading.Tasks;

using WorkflowCore.Interface;
using WorkflowCore.Models;

using SkatWorker.Workflows.Public.Steps.CopyFiles.Parameters;
using SkatWorkerAPI.Models;


namespace SkatWorkerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowController _workflowController;
        private readonly IPersistenceProvider _persistenceProvider;

        public WorkflowController(IWorkflowController workflowController, IPersistenceProvider persistenceProvider)
        {
            _workflowController = workflowController;
            _persistenceProvider = persistenceProvider;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkflowInstance>> Get(string id)
        {
            var result = await _persistenceProvider.GetWorkflowInstance(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<WorkflowInstance>> Post(string id, [FromBody] CopyFileParam data)
        {
            var instanceId = await _workflowController.StartWorkflow(id, data);
            var result = await _persistenceProvider.GetWorkflowInstance(instanceId);

            return Ok(result);

            //return Created(instanceId, _mapper.Map<WorkflowInstance>(result));
        }

        [HttpPut("{id}/suspend")]
        public async Task Suspend(string id)
        {
            var result = await _workflowController.SuspendWorkflow(id);

            if (result)
                Response.StatusCode = 200;
            else
                Response.StatusCode = 400;
        }

        [HttpPut("{id}/resume")]
        public async Task Resume(string id)
        {
            var result = await _workflowController.ResumeWorkflow(id);

            if (result)
                Response.StatusCode = 200;
            else
                Response.StatusCode = 400;
        }

        [HttpDelete("{id}")]
        public async Task Terminate(string id)
        {
            var result = await _workflowController.TerminateWorkflow(id);

            if (result)
                Response.StatusCode = 200;
            else
                Response.StatusCode = 400;
        }
    }
}
