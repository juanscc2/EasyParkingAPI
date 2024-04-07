using EasyParking.Api.Data.DTOS.Request;
using EasyParking.Api.Data.DTOS.Response;
using EasyParking.Api.Data.Models;

namespace EasyParking.Api.Services.Contracts
{
    public interface UserService
    {
        Task<List<UserResponse>> GetUsersAsync();
        Task<User> UpdateUserAsync(int id, UpdateUserRequest model);
        Task<bool> CreateUserASync(UserRequest userRequest);
        Task<bool> AuthenticateAsync(AuthenticationRequest authenticationRequest);

    }
}
