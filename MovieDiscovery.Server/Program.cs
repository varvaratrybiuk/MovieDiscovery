using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieDiscovery.Server.Context;
using MovieDiscovery.Server.Endpoints;
using MovieDiscovery.Server.Exceptions;
using MovieDiscovery.Server.Interfaces;
using MovieDiscovery.Server.Services;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(allowedOrigins!)
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                      });
});

builder.Services.AddDbContext<MovieDBContext>(configure =>
{
    configure.UseSqlite(builder.Configuration.GetConnectionString("sqlConnection"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";

            var response = new { message = "Потрібна автентифікація" };
            var json = System.Text.Json.JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(json);
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();


app.MapGroup("/movies").MapMovieEndPoints();
app.MapGroup("/genres").MapGenreEndPoints();
app.MapGroup("/account").MapAccountEndPoints();

app.Run();
