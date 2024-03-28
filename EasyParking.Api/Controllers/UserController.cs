using EasyParking.Api.Data;
using EasyParking.Api.Data.DTOS.Request;
using EasyParking.Api.Data.Models;
using EasyParking.Api.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EasyParking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        private EasyParkingContext _context;

        
        [HttpGet]
        public IEnumerable<User> Get() => _context.User.ToList();
        [HttpPost("createUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CrearUsuario(UserRequest usuarioDTO)
        {
            try
            {
                // Llama al servicio para crear el usuario
                bool succesfulCreation = await _userService.CreateUserASync(usuarioDTO);

                // Verifica si el usuario se creó exitosamente
                if (succesfulCreation)
                {
                    return Ok("Usuario creado exitosamente");
                }
                else
                {
                    return BadRequest("El usuario no pudo ser creado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el usuario: {ex.Message}");
            }
        }
    }
}
