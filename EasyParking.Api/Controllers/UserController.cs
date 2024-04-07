using EasyParking.Api.Data;
using EasyParking.Api.Data.DTOS.Request;
using EasyParking.Api.Data.DTOS.Response;
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
        

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var userDTOs = await _userService.GetUsersAsync();
                return Ok(userDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los usuarios: {ex.Message}");
            }
        }
        [HttpPost("CreateUsers")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateUser(UserRequest usuarioDTO)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest model)
        {
            try
            {
                var updatedUser = await _userService.UpdateUserAsync(id, model);
                var updateUserDTO = new UserResponse
                {
                    username = updatedUser.Username,
                    email = updatedUser.Email,
                    name = updatedUser.Name,
                };
                return Ok(updateUserDTO);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Usuario no encontrado")
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }


    }
}
