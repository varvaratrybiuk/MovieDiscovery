using MovieDiscovery.Server.Contracts;

namespace MovieDiscovery.Server.Helpers
{
    public static class ValidationUtilities
    {
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
        public static string ValidateUserRequest(CreateUserRequest user)
        {
            if (string.IsNullOrEmpty(user.Username))
            {
                return "Вкажіть ім'я користувача.";
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                return "Вкажіть електронну пошту.";
            }

            if (!user.Email.Contains('@') || !user.Email.Contains('.'))
            {
                return "Введено некоректний формат електронної пошти.";
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                return "Вкажіть пароль.";
            }

            if (user.Password.Length < 8)
            {
                return "Пароль повинен бути не менше 8 символів.";
            }

            return string.Empty;
        }
    }
}
