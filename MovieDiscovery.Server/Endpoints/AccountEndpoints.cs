using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using MovieDiscovery.Server.Contracts.User;
using MovieDiscovery.Server.Helpers;
using MovieDiscovery.Server.Interfaces;
using MovieDiscovery.Server.Models;
using System.Security.Claims;

namespace MovieDiscovery.Server.Endpoints
{
    /// <summary>
    /// Клас, що містить ендпоїнти для обробки запитів, пов'язаних з обліковими записами користувачів.
    /// </summary>
    public static class AccountEndpoints
    {
        /// <summary>
        /// Реєструє всі ендпоїнти для обробки запитів, пов'язаних з обліковими записами користувачів.
        /// </summary>
        /// <param name="app">Інтерфейс для налаштування маршрутів.</param>
        /// <returns>Інтерфейс для налаштування маршрутів.</returns>
        public static IEndpointRouteBuilder MapAccountEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", GetUserById);

            app.MapPost("/register", RegisterUser)
               .AddEndpointFilter(async (context, next) =>
               {
                   var user = context.GetArgument<CreateUserRequest>(0);

                   var validationError = ValidationUtilities.ValidateCreateUserRequest(user);

                   if (!string.IsNullOrEmpty(validationError))
                   {
                       return Results.Problem(validationError, statusCode: 400);
                   }

                   return await next(context);
               });

            app.MapPost("/login", LoginUser);

            app.MapPost("/logout", (Delegate)LogoutUser).RequireAuthorization(); ;

            app.MapPut("/update/{id}", UpdateUser).RequireAuthorization().AddEndpointFilter(async (context, next) =>
            {
                var user = context.GetArgument<UpdateUserRequest>(0);

                var validationError = ValidationUtilities.ValidateUpdateUserRequest(user);

                if (!string.IsNullOrEmpty(validationError))
                {
                    return Results.Problem(validationError, statusCode: 400);
                }

                return await next(context);
            });

            app.MapDelete("/delete/{id}", DeleteUser).RequireAuthorization(); ;

            return app;
        }

        /// <summary>
        /// Отримання користувача за його ID.
        /// </summary>
        /// <param name="id">Унікальний ID користувача</param>
        /// <param name="service">Сервіс для роботи з користувачами</param>
        /// <returns>
        /// Якщо користувач знайдений, повертає статус 200 з даними користувача. Якщо не знайдений - повертає статус 404.
        /// </returns>
        /// <response code="200">Користувач знайдений</response>
        /// <response code="404">Користувач не знайдений</response>
        /// <response code="500">Внутрішня помилка</response>
        private static async Task<IResult> GetUserById(int id, IUserService service)
        {
            var result = await service.GetUserByIdAsync(id);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        }

        /// <summary>
        /// Реєстрація нового користувача в системі.
        /// </summary>
        /// <param name="user">Об'єкт, що містить дані для реєстрації нового користувача</param>
        /// <param name="service">Сервіс для роботи з користувачами</param>
        /// <returns>Статус 201 при успішній реєстрації</returns>
        /// <response code="201">Користувач успішно зареєстрований</response>
        /// <response code="400">Некоректний запит</response>
        /// <response code="500">Внутрішня помилка</response>
        private static async Task<IResult> RegisterUser(CreateUserRequest user, IUserService service)
        {
            var result = await service.AddUser(user);
            return Results.Created($"/users/{result.Id}", result);
        }

        /// <summary>
        /// Логін користувача.
        /// </summary>
        /// <param name="user">Об'єкт, що містить дані для автентифікації користувача</param>
        /// <param name="service">Сервіс для роботи з користувачами</param>
        /// <param name="httpContext">Контекст HTTP-запиту для управління сесією</param>
        /// <returns>
        /// Статус 200 при успішному вході, статус 401 при невірних даних для входу.
        /// </returns>
        /// <response code="200">Вхід успішний</response>
        /// <response code="401">Невірні облікові дані</response>
        /// <response code="404">Користувач не знайдений</response>
        /// <response code="500">Внутрішня помилка</response>
        private static async Task<IResult> LoginUser(UserRequest user, IUserService service, HttpContext httpContext)
        {
            var existingUser = await service.GetUserByEmailAndUsernameAsync(user.Username, string.Empty) as UserResponseWithPassword;
            if (existingUser is null)
            {
                return Results.NotFound();
            }

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(null, existingUser.Password, user.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Results.Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return Results.Ok(new { message = "Вхід успішний" });
        }

        /// <summary>
        /// Вихід з акаунту.
        /// </summary>
        /// <param name="httpContext">Контекст HTTP-запиту для видалення сесії</param>
        /// <returns>Статус 200 при успішному виході</returns>
        /// <response code="200">Вихід успішний</response>
        /// <response code="500">Внутрішня помилка</response>
        private static async Task<IResult> LogoutUser(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Results.Ok(new { message = "Вихід успішний" });
        }

        /// <summary>
        /// Оновлення даних користувача.
        /// </summary>
        /// <param name="id">ID користувача для оновлення</param>
        /// <param name="user">Об'єкт, що містить дані для оновлення даних користувача</param>
        /// <param name="service">Сервіс для роботи з користувачами</param>
        /// <returns>Статус 204 при успішному оновленні</returns>
        /// <response code="204">Оновлення успішне</response>
        /// <response code="401">Користувач не увійшов у систему</response>
        /// <response code="404">Користувач не знайдений</response>
        /// <response code="500">Внутрішня помилка</response>
        private static async Task<IResult> UpdateUser(UpdateUserRequest user, int id, IUserService service)
        {
            var updatedUser = await service.UpdateUserAsync(user, id);
            return updatedUser is not null ? Results.NoContent() : Results.NotFound("Користувач не знайдений.");
        }

        /// <summary>
        /// Видалення користувача.
        /// </summary>
        /// <param name="id">ID користувача для видалення</param>
        /// <param name="service">Сервіс для роботи з користувачами</param>
        /// <returns>Статус 204 при успішному видаленні</returns>
        /// <response code="204">Користувач успішно видалений</response>
        /// <response code="401">Користувач не увійшов у систему</response>
        /// <response code="404">Користувач не знайдений</response>
        /// <response code="500">Внутрішня помилка</response>
        private static async Task<IResult> DeleteUser(int id, IUserService service)
        {
            var deleted = await service.DeleteUserAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound("Користувач не знайдений.");
        }


    }

}
