using System;
using System.Collections.Generic;
using System.Linq;
using FilmesIoasys.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesIoasys.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login()
        {
            return Ok(TokenService.GeraToken(new Dominio.Entidades.Usuario(
                "Leonardo",
                22,
                Dominio.Enums.TipoUsuario.Admin)));
        }

        [HttpGet]
        [Authorize(Roles = "0")]
        public IActionResult GET()
        {
            return Ok(User.Identity.Name);
        }
    }
}
