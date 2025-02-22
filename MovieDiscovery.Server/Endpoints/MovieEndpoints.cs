using api.Contracts;
using api.Helpers;
using api.Interfaces;

namespace api.Endpoints
{
    public static class MovieEndpoints
    {
        public static IEndpointRouteBuilder MapMovieEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", async (IMovieService service) =>
            {
                var result = await service.GetAllAsync();
                return Results.Ok(result);

            });

            app.MapGet("/random", async (IMovieService service) =>
            {
                var result = await service.GetRandomMovieAsync();
                return result is not null ? Results.Ok(result) : Results.NotFound();
            });

            app.MapGet("/{name}", async (string name, IMovieService service) =>
            {
               var result = await service.GetByTitleAsync(name);
               return result is not null ? Results.Ok(result) : Results.NotFound();
            });

            app.MapPost("/add", async (CreateMovieRequest create, IMovieService service) =>
            {
                var result =  await service.AddMovieAsync(create);
                return Results.Created($"movie/{result.Title}", result);
            }).AddEndpointFilter(async (context, next) =>
            {
                var movie = context.GetArgument<CreateMovieRequest>(0);

                var validationError = ValidationUtilities.ValidateMovieRequest(movie);

                if (!string.IsNullOrEmpty(validationError))
                {
                    return Results.Problem(validationError, statusCode: 400);
                }

                return await next(context);
            });

            return app;
        }
    }
}
