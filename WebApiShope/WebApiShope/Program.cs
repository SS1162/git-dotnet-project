using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepositoriesUsers, RepositoriesUsers>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IPasswordService,PasswordService>();
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
