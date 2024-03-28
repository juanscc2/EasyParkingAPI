using EasyParking.Api.Data.DTOS.Request;

namespace EasyParking.Api.Services.Contracts
{
    public interface UserService
    {
        Task<bool> CreateUserASync(UserRequest userRequest);
        Task<bool> AuthenticateAsync(AuthenticationRequest authenticationRequest);

    }
}
