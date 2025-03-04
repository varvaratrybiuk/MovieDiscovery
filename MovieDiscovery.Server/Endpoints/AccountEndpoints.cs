using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using MovieDiscovery.Server.Contracts;
using MovieDiscovery.Server.Helpers;
using MovieDiscovery.Server.Interfaces;
using MovieDiscovery.Server.Models;
using System.Security.Claims;

namespace MovieDiscovery.Server.Endpoints
{
    public static class AccountEndpoints
    {
        public static IEndpointRouteBuilder MapAccountEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", async (int id, IUserService service) =>
            {
                var result = await service.GetUserByIdAsync(id);
                return result is not null ? Results.Ok(result) : Results.NotFound();
            });

            app.MapPost("/register", async (CreateUserRequest user, IUserService service) =>
            {
                var result = await service.AddUser(user);
                Results.Created($"/users/{result.Id}", result);
            }).AddEndpointFilter(async (context, next) =>
            {
                var user = context.GetArgument<CreateUserRequest>(0);

                var validationError = ValidationUtilities.ValidateUserRequest(user);

                if (!string.IsNullOrEmpty(validationError))
                {
                    return Results.Problem(validationError, statusCode: 400);
                }

                return await next(context);
            });

            app.MapPost("/login", async (UserRequest user, IUserService service, HttpContext httpContext) =>
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

            });

            app.MapPost("/logout", async (HttpContext httpContext) =>
            {
                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Results.Ok(new { message = "Вихід успішний" });
            });

            return app;
        }
    }
}
