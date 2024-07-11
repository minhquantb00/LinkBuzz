using LinkBuzz.Application.InterfaceService;
using LinkBuzz.Application.Payloads.RequestModels.AuthModels;
using LinkBuzz.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkBuzz.Api.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromForm] Request_RegisterUser request)
        {
            return Ok(await _authService.Register(request));
        }
    }
}
