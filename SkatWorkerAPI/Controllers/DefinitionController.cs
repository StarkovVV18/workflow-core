﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WorkflowCore.Interface;
using System.Threading.Tasks;
using WorkflowCore.Models;
using SkatWorker.Application.Interfaces.Services;
using SkatWorker.Application.Interfaces.Models;

namespace SkatWorkerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DefinitionController : ControllerBase
    {
        private readonly ILogger<DefinitionController> _logger;
        private readonly IDefinitionService _definitionService;
        private readonly IPersistenceProvider _persistenceProvider;

        public DefinitionController(ILogger<DefinitionController> logger, IDefinitionService definitionService, IPersistenceProvider persistenceProvider)
        {
            _logger = logger;
            _definitionService = definitionService;
            _persistenceProvider = persistenceProvider;
        }

        [HttpPost]
        public async Task<ActionResult<WorkflowDefinition>> Post([FromBody] IEnumerable<IDefinitionModel> datasets)
        {
            var result = _definitionService.RegisterNewDefinition(datasets);

            if (result != null)
                return NoContent();

            return BadRequest();
        }
    }
}