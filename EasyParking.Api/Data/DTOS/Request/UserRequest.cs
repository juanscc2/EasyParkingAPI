using Microsoft.Identity.Client;

namespace EasyParking.Api.Data.DTOS.Request
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string name { get; set; }

        public int IdRole { get; set; }
    }
}
