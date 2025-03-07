using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieDiscovery.Server.Context;
using MovieDiscovery.Server.Contracts.User;
using MovieDiscovery.Server.Exceptions;
using MovieDiscovery.Server.Interfaces;
using MovieDiscovery.Server.Models;

namespace MovieDiscovery.Server.Services
{
    /// <summary>
    /// Сервіс для керування користувачами.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly MovieDBContext _context;

        /// <summary>
        /// Конструктор класу UserService.
        /// </summary>
        /// <param name="context">Контекст бази даних.</param>
        public UserService(MovieDBContext context) => _context = context;

        /// <summary>
        /// Додавання нового користувача до бази даних.
        /// </summary>
        /// <param name="user">Об'єкт, що містить дані для створення користувача.</param>
        /// <returns>Об'єкт <see cref="UserResponse"/> з інформацією про користувача.</returns>
        /// <exception cref="UserAlreadyExistsException">Виникає, якщо користувач з такою електронною поштою або ім'ям вже існує.</exception>
        /// <exception cref="Exception">Може виникнути у разі неочікуваної помилки.</exception>
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

        /// <summary>
        /// Видалення користувача за його ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор користувача.</param>
        /// <returns>True, якщо користувача видалено, інакше - false.</returns>
        /// <exception cref="Exception">Може виникнути у разі неочікуваної помилки.</exception>
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Отримання користувача за електронною потошою або ім'ям користувача.
        /// </summary>
        /// <param name="username">Ім'я користувача.</param>
        /// <param name="email">Електронна пошта користувача.</param>
        /// <returns>Об'єкт <see cref="UserResponseWithPassword"/> з інформацією про користувача або null, якщо користувача не знайдено.</returns>
        /// <exception cref="Exception">Може виникнути у разі неочікуваної помилки.</exception>
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

        /// <summary>
        /// Отримання користувача за ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор користувача.</param>
        /// <returns>Об'єкт <see cref="UserResponse"/> з інформацією про користувача або null, якщо користувача не знайдено.</returns>
        /// <exception cref="Exception">Може виникнути у разі неочікуваної помилки.</exception>
        public async Task<UserResponse?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Where(u => u.Id == id)
                .SingleOrDefaultAsync();

            if (user is null)
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

        /// <summary>
        /// Оновлювання даних користувача.
        /// </summary>
        /// <param name="user">Об'єкт, що містить дані для оновлення користувача.</param>
        /// <param name="userId">Ідентифікатор користувача.</param>
        /// <returns>Об'єкт <see cref="UserResponse"/> з оновленою інформацією або null, якщо користувача не знайдено.</returns>
        /// <exception cref="Exception">Може виникнути у разі неочікуваної помилки.</exception>
        public async Task<UserResponse?> UpdateUserAsync(UpdateUserRequest user, int userId)
        {
            var existingUser = await _context.Users.FindAsync(userId);
            var passwordHasher = new PasswordHasher<object>();

            if (existingUser is null)
            {
                return null;
            }

            existingUser.Username = string.IsNullOrEmpty(user.Username) ? existingUser.Username : user.Username;
            existingUser.Email = string.IsNullOrEmpty(user.Email) ? existingUser.Email : user.Email;
            if (!string.IsNullOrEmpty(user.Password))
            {
                existingUser.PasswordHash = passwordHasher.HashPassword(null, user.Password);
            }

            await _context.SaveChangesAsync();
            return new UserResponse
            {
                Id = existingUser.Id,
                Username = existingUser.Username,
                Email = existingUser.Email,
            };
        }
    }
}
