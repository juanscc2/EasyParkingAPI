using EasyParking.Api.Data;
using EasyParking.Api.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyParking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUsers : ControllerBase
    {
        private EasyParkingContext _context;

        public GetUsers(EasyParkingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<User> Get() => _context.Users.ToList();

    }
}
