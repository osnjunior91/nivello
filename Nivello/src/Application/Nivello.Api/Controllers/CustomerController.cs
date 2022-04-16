using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var result = await _mediator.Send(new GetCustomersByNameQuery(name));
            return Ok(result);
        }
    }
}
