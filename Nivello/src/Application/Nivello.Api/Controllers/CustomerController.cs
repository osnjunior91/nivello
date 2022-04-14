using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nivello.Domain.Commands.Customer.Commands;
using System.Threading.Tasks;

namespace Nivello.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
