using MovieDiscovery.Server.Contracts.User;

namespace MovieDiscovery.Server.Interfaces
{
    /// <summary>
    /// Інтерфейс для сервісу користувачів.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Отримання користувача за електронною поштою та ім'ям користувача.
        /// </summary>
        /// <param name="username">Ім'я користувача.</param>
        /// <param name="email">Електронна пошта користувача.</param>
        /// <returns>Об'єкт <see cref="UserResponse"/> з даними користувача або null, якщо користувача не знайдено.</returns>
        Task<UserResponse?> GetUserByEmailAndUsernameAsync(string username, string email);

        /// <summary>
        /// Отримання користувача за його ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор користувача.</param>
        /// <returns>Об'єкт <see cref="UserResponse"/> з даними користувача або null, якщо користувача не знайдено.</returns>
        Task<UserResponse?> GetUserByIdAsync(int id);

        /// <summary>
        /// Додавання нового користувача.
        /// </summary>
        /// <param name="user">Запит на створення користувача.</param>
        /// <returns>Об'єкт <see cref="UserResponse"/> з даними доданого користувача.</returns>
        Task<UserResponse> AddUser(CreateUserRequest user);

        /// <summary>
        /// Оновлення інформації про користувача.
        /// </summary>
        /// <param name="user">Запит на оновлення користувача.</param>
        /// <param name="userId">Ідентифікатор користувача, інформацію якого потрібно оновити.</param>
        /// <returns>Об'єкт <see cref="UserResponse"/> з оновленими даними користувача.</returns>
        Task<UserResponse?> UpdateUserAsync(UpdateUserRequest user, int userId);

        /// <summary>
        /// Видалення користувача за його ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор користувача, якого потрібно видалити.</param>
        /// <returns>True, якщо користувач успішно видалений, інакше false.</returns>
        Task<bool> DeleteUserAsync(int id);
    }
}
