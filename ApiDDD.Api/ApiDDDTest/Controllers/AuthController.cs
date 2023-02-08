using ApiDDD.Application.Services.Auth;
using ApiDDD.Contracts.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ApiDDD.Api.Controllers
{
   
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authService.Register(
                request.firstName,
                request.lastName,
                request.email,
                request.password);

            var response = new AuthResponse(
               authResult.User.Id,
               authResult.User.FirstName,
               authResult.User.LastName,
               authResult.User.Email,
               authResult.token);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult login(LoginRequest request)
        {
            var authResult = _authService.Login(
                request.email,
                request.password);

            var response = new AuthResponse(
               authResult.User.Id,
               authResult.User.FirstName,
               authResult.User.LastName,
               authResult.User.Email,
               authResult.token);

            return Ok(request);
        }
    }
}
