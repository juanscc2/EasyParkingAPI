using EasyParking.Api.Data;
using EasyParking.Api.Data.DTOS.Request;
using EasyParking.Api.Data.Models;
using EasyParking.Api.Services.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Net;

namespace EasyParking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationUser : ControllerBase
    {
        private readonly UserService _authenticationService;

        public AuthenticationUser (UserService autentication)
        {
            _authenticationService = autentication;
        }
        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task <IActionResult> Login([FromBody] AuthenticationRequest model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { message = "Por favor, proporcione nombre de usuario y contraseña" });
            }

            bool isAuthenticated = await _authenticationService.AuthenticateAsync(model);

            if (isAuthenticated)
            {
                
                return Ok();
            }
           
                return Unauthorized("Tus credenciales no coinciden");
           
        }
    }
}
