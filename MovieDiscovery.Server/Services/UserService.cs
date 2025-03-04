using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieDiscovery.Server.Context;
using MovieDiscovery.Server.Contracts;
using MovieDiscovery.Server.Exceptions;
using MovieDiscovery.Server.Interfaces;
using MovieDiscovery.Server.Models;

namespace MovieDiscovery.Server.Services
{
    public class UserService : IUserService
    {
        private readonly MovieDBContext _context;

        public UserService(MovieDBContext context) => _context = context;
        public async Task<UserResponse> AddUser(CreateUserRequest user)
        {
            var existingUser = await GetUserByEmailAndUsernameAsync(user.Username, user.Email);

            if (existingUser is not null)
            {
                throw new UserAlreadyExistsException();
            }

            var passwordHasher = new PasswordHasher<object>();
            var newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                PasswordHash = passwordHasher.HashPassword(null, user.Password)
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new UserResponse
            {
                Id = newUser.Id,
                Username = newUser.Username,
                Email = newUser.Email,
            };
        }

        public async Task<UserResponse?> GetUserByEmailAndUsernameAsync(string? username, string? email)
        {
            var user = await _context.Users
                    .Where(u => u.Username == username || u.Email == email)
                    .FirstOrDefaultAsync();

            if (user is null)
                return null;

            return new UserResponseWithPassword
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.PasswordHash
            };
        }

        public async Task<UserResponse?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Where(u => u.Id == id)
                .SingleOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
            };
        }
    }
}
