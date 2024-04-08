namespace EasyParking.Api.Data.DTOS.Request
{
    public class UpdateUserRequest
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }   

        public int IdRole { get; set; }
    }
}
