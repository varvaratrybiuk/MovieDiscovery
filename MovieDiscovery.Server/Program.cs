using api.Context;
using api.Endpoints;
using api.Exceptions;
using api.Interfaces;
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieDBContext>(configure =>
{
    configure.UseSqlite(builder.Configuration.GetConnectionString("sqlConnection"));
});

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();

app.MapGroup("/movies").MapMovieEndPoint();
app.MapGroup("/genres").MapGenreEndPoint();

app.Run();
