using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nivello.Domain.Commands.Customer.Commands;
using Nivello.Domain.Queries.Customer.Queries;
using Nivello.Lib.Nivello.Application;
using System.Threading.Tasks;

namespace Nivello.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    public class CustomerController : ControllerBaseAPI
    {
        public IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("name")]
        public async Task<IActionResult> GetByName([FromQuery] GetCustomersByNameQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
