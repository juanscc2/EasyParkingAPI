namespace EasyParking.Api.Services.UserService
{
    public interface IAutentication
    {

        Task<bool> AuthenticateAsync(string username, string password);



    }
}
