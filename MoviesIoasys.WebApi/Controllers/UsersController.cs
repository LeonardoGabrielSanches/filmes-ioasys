using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesIoasys.Domain.Interfaces.Repositories;
using MoviesIoasys.Domain.Services.Users;
using MoviesIoasys.WebApi.Provider;
using MoviesIoasys.WebApi.ViewModels.Users;
using System.Linq;

namespace MoviesIoasys.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetUsersNotAdminActive([FromServices] IUsersRepository usersRepository,
                                                    [FromQuery] int page = 0,
                                                    int size = 5)
        {
            var users = usersRepository.GetAllNotAdmAndActive(page, size);

            return Ok(users.Select(user => (UserViewModel)user));
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUser([FromServices] CreateUserService createUserService,
                                        [FromBody] CreateUserViewModel createUserViewModel)
        {
            var user = createUserService.CreateUser(createUserViewModel);

            if (!user.IsValid)
                return BadRequest(user.NotificationError);

            return Created("", (UserViewModel)user);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateUser([FromServices] UpdateUserService updateUserService,
                                        [FromBody] UpdateUserViewModel updateUserViewModel)
        {
            string id = TokenProvider.GetIdFromToken(User);

            var user = updateUserService.UpdateUser(UpdateUserViewModel.GetUpdateUserDTO(updateUserViewModel, id));

            if (!user.IsValid)
                return BadRequest(user.NotificationError);

            return Ok((UserViewModel)user);
        }

        [HttpPatch]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateActiveStatus([FromServices] UpdateActiveStatusService updateActiveStatusService,
                                                [FromBody] UpdateUserActiveStatusViewModel updateUserActiveStatusViewModel)
        {
            string email = TokenProvider.GetEmailFromToken(User);

            var user = updateActiveStatusService.UpdateActiveStatus(UpdateUserActiveStatusViewModel.GetUserActiveStatusDTO(updateUserActiveStatusViewModel,
                                                                                                                           email));

            if (!user.IsValid)
                return BadRequest(user.NotificationError);

            return Ok((UserViewModel)user);
        }
    }
}
