using MovieDiscovery.Server.Contracts.Movie;
using MovieDiscovery.Server.Contracts.User;
using System.Net.Mail;

namespace MovieDiscovery.Server.Helpers
{
    /// <summary>
    /// Статичний клас для обробки валідації запитів.
    /// </summary>
    public static class ValidationUtilities
    {
        /// <summary>
        /// Валідує запит на створення фільму.
        /// </summary>
        /// <param name="movie">Об'єкт, що містить дані для створення фільму.</param>
        /// <returns>Повертає повідомлення про помилку, якщо валідація не пройдена, або порожній рядок, якщо все вірно.</returns>
        public static string ValidateMovieRequest(CreateMovieRequest movie)
        {
            if (string.IsNullOrEmpty(movie.Title))
            {
                return "Вкажіть заголовок.";
            }

            if (string.IsNullOrEmpty(movie.Description))
            {
                return "Вкажіть опис.";
            }

            if (movie.Year < 1888 || movie.Year > DateTime.Now.Year)
            {
                return "Рік виходу має бути в межах від 1888 до поточного року.";
            }

            if (movie.Rating < 0 || movie.Rating > 10)
            {
                return "Рейтинг має бути від 0 до 10.";
            }

            if (movie.GenresID == null || !movie.GenresID.Any())
            {
                return "Оберіть хоча б один жанр.";
            }

            if (movie.GenresID.Any(m => m <= 0))
            {
                return "ID жанру має бути більше 0.";
            }

            return string.Empty;
        }

        /// <summary>
        /// Валідує запит на створення користувача.
        /// </summary>
        /// <param name="user">Об'єкт, що містить дані для створення користувача.</param>
        /// <returns>Повертає повідомлення про помилку, якщо валідація не пройдена, або порожній рядок, якщо все вірно.</returns>
        public static string ValidateCreateUserRequest(CreateUserRequest user)
        {
            if (string.IsNullOrEmpty(user.Username))
            {
                return "Вкажіть ім'я користувача.";
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                return "Вкажіть електронну пошту.";
            }

            if (!IsValidEmail(user.Email))
            {
                return "Введено некоректний формат електронної пошти.";
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                return "Вкажіть пароль.";
            }

            // Перевірка пароля для створення користувача
            return ValidatePassword(user.Password);
        }

        /// <summary>
        /// Валідує запит на оновлення користувача.
        /// </summary>
        /// <param name="user">Об'єкт, що містить дані для оновлення користувача.</param>
        /// <returns>Повертає повідомлення про помилку, якщо валідація не пройдена, або порожній рядок, якщо все вірно.</returns>
        public static string ValidateUpdateUserRequest(UpdateUserRequest user)
        {

            if (!string.IsNullOrEmpty(user.Email))
    {
        if (!IsValidEmail(user.Email))
        {
            return "Введено некоректний формат електронної пошти.";
        }
    }

            if (!string.IsNullOrEmpty(user.Password))
            {
                return ValidatePassword(user.Password);
            }

            return string.Empty;
        }

        private static string ValidatePassword(string password)
        {
            if (password.Length < 8)
            {
                return "Пароль повинен бути не менше 8 символів.";
            }

            return string.Empty;
        }
        private static bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
