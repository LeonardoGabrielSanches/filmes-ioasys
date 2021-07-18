using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesIoasys.Domain.Services.Users;
using MoviesIoasys.WebApi.ViewModels;
using MoviesIoasys.WebApi.ViewModels.Users;

namespace MoviesIoasys.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login([FromServices] LoginService loginService,
                                   [FromBody] LoginViewModel loginViewModel)
        {
            var user = loginService.Login(loginViewModel);
            if (!user.IsValid)
                return BadRequest(user.NotificationError);

            return Ok(AuthViewModel.GenerateUserToken(user));
        }
    }
}
