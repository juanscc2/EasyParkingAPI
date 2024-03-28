namespace EasyParking.Api.Services.Implementation
    
{
    using EasyParking.Api.Data;
    using EasyParking.Api.Data.DTOS.Request;
    using EasyParking.Api.Data.Models;
    using EasyParking.Api.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using System.Threading.Tasks;

    public class UserServiceImplement : UserService
    {
        public readonly EasyParkingContext _context;


        public UserServiceImplement(EasyParkingContext context) {
        _context=context;
        }
        public async Task<bool> AuthenticateAsync(AuthenticationRequest authenticationRequest)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Username == authenticationRequest.Username && u.Password == authenticationRequest.Password);
            return user != null;
        }

        public async Task<bool> CreateUserASync(UserRequest userRequest)
        {
            if (await _context.User.AnyAsync(u => userRequest.username == u.Username))
            {
                // Si ya existe un usuario con el mismo nombre de usuario, devolvemos false para indicar que no se pudo crear el usuario
                return false;
            }
            // Crear una nueva instancia de Usuario con los datos proporcionados
            var newUser = new User
            {
                Id = userRequest.Id,
                Username = userRequest.username,
                Email = userRequest.email,
                Password = userRequest.password,
                Name = userRequest.name,
                IdRole = userRequest.IdRole
            };

            // Agregar el nuevo usuario al DbContext y guardar los cambios en la base de datos
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            // Devolver true para indicar que el usuario se creó exitosamente
            return true;
        }
    }
}
