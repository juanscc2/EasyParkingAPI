namespace EasyParking.Api.Services.Implementation
    
{
    using EasyParking.Api.Data;
    using EasyParking.Api.Data.DTOS.Request;
    using EasyParking.Api.Data.DTOS.Response;
    using EasyParking.Api.Data.Models;
    using EasyParking.Api.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using System.Collections.Generic;
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
                Id=userRequest.Id,
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

        public async Task<List<UserResponse>> GetUsersAsync()
        {
            var users = await _context.User.ToListAsync();
            var userDTOs = new List<UserResponse>();

            foreach (var user in users)
            {
                var userDTO = new UserResponse
                {
                    username = user.Username,
                    email = user.Email,
                    name=user.Name,
                    
                };

                userDTOs.Add(userDTO);
            }

            return userDTOs;
        }

        public async Task<User> UpdateUserAsync(int id, UpdateUserRequest model)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            // Actualizar propiedades del usuario con los datos del modelo
            user.Username = model.UserName;
            user.Name = model.Name;
            user.Email = model.Email;
            user.IdRole = model.IdRole;
            // Agrega otras propiedades según sea necesario

            // Marcar el usuario como modificado en el contexto y guardar los cambios
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }
    }

}

