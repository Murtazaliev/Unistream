using Application.Common;
using Application.Entity;
using Domain;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityTController : ControllerBase
    {
        private IMediator _mediator;
        public EntityTController([NotNull] IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("get-by-id/{id}")]
        [ProducesResponseType(typeof(EntityDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<EntityDTO>> GetById([Required] Guid id)
        {

                var query = new GetByIdQuery(id);
                var queryResult = (await _mediator.Send(query)).Adapt<EntityDTO>();
                return queryResult;

        }
        [HttpPost("insert")]
        [ProducesResponseType(typeof(EntityDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EntityDTO>> Insert([Required] string insert)
        {
            try
            {
                var query = new InsertQuery(insert);
                var result = (await _mediator.Send(query)).Adapt<EntityDTO>();
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
