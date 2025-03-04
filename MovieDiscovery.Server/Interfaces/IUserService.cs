using MovieDiscovery.Server.Contracts;

namespace MovieDiscovery.Server.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse?> GetUserByEmailAndUsernameAsync(string username, string email);
        Task<UserResponse?> GetUserByIdAsync(int id);
        Task<UserResponse> AddUser(CreateUserRequest user);
    }
}
