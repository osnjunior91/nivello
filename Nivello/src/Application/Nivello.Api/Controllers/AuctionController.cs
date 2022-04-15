using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nivello.Domain.Commands.Auctions.Commands;
using Nivello.Lib.Nivello.Application;
using System.Threading.Tasks;

namespace Nivello.Api.Controllers
{
    [Route("api/v1/auction")]
    [ApiController]
    public class AuctionController : ControllerBaseAPI
    {
        public IMediator _mediator;

        public AuctionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("bid")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Post([FromBody] CreateAuctionsBidCommand command)
        {
            command.CustomerId = GetCurrentUserId();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
