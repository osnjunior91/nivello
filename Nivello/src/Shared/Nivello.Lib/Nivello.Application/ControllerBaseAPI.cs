using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Nivello.Lib.Nivello.Application
{
    [ApiController]
    public abstract class ControllerBaseAPI : Controller
    {
        protected Guid GetCurrentUserId()
        {
            return new Guid(this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
