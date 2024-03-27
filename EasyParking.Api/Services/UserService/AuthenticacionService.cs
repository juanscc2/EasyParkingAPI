using EasyParking.Api.Data;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;

namespace EasyParking.Api.Services.UserService
{
    public class AuthenticacionService : IAutentication
    {
        private readonly EasyParkingContext _context;

        public AuthenticacionService(EasyParkingContext context)
        {
            _context = context;
        }

          public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            return user != null;
        }
    }
}
