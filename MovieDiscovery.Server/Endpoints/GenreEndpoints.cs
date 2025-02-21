using api.Interfaces;

namespace api.Endpoints
{
    public static class GenreEndpoints
    {
        public static IEndpointRouteBuilder MapGenreEndPoint(this IEndpointRouteBuilder app)
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
