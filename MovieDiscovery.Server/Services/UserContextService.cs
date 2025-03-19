using System.Security.Claims;

namespace MovieDiscovery.Server.Services
{
    /// <summary>
    /// Сервіс для роботи з контекстом користувача в HTTP запитах.
    /// </summary>
    public class UserContextService
    {
        /// <summary>
        /// Отримання userId з контексту HTTP.
        /// </summary>
        /// <param name="httpContext">Контекст HTTP.</param>
        /// <returns>userId користувача або null, якщо користувач не авторизований.</returns>
        public static int? GetUserIdFromHttpContext(HttpContext httpContext)
        {
            var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim is not null ? int.Parse(userIdClaim.Value) : null;
        }
    }
}
