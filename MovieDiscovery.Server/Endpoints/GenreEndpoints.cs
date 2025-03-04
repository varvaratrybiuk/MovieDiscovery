using MovieDiscovery.Server.Interfaces;

namespace MovieDiscovery.Server.Endpoints
{
    public static class GenreEndpoints
    {
        public static IEndpointRouteBuilder MapGenreEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", async (IGenreService service) =>
            {
                var result = await service.GetAllAsync();
                return Results.Ok(result);

            });

            return app;
        }
    }
}
