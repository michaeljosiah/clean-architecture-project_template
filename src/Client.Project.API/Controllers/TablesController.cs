using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Client.Project.API.Models;
using Client.Project.Application.Tables.Queries.GetAvailableTables;
using Client.Project.Domain.Interfaces.Commands;
using Client.Project.Domain.Interfaces.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Client.Project.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json", "application/xml")]
    [ProducesResponseType(500)]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private ICommandDispatcher commandDispatcher;
        private IQueryDispatcher queryDispatcher;
        private readonly IMapper mapper;
        private readonly ILogger<TablesController> logger;

        public TablesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ILogger<TablesController> logger, IMapper mapper)
        {
            this.commandDispatcher = commandDispatcher ?? throw new ArgumentException(nameof(commandDispatcher));
            this.queryDispatcher = queryDispatcher ?? throw new ArgumentException(nameof(queryDispatcher));
            this.logger = logger ?? throw new ArgumentException(nameof(ILogger<TablesController>));
            this.mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        /// <summary>
        /// Retrieves a list of tables
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<TableDto>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        public async Task<IActionResult> Get()
        {
            try
            {
                
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var query = new GetAvailableTableQuery();
                var result = await queryDispatcher.ExecuteAsync(query);
                if (!result.Tables.Any())
                {
                    return NotFound(query);
                }

                var response = mapper.Map<List<TableDto>>(result.Tables);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger?.LogError($"Exception caught {nameof(TablesController)}");
                throw ex;
            }
            
        }
    }
}