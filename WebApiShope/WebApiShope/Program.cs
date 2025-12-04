using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepositoriesUsers, RepositoriesUsers>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IPasswordService,PasswordService>();
builder.Services.AddDbContext<MyShop330683525Context>(option => option.UseSqlServer
("Data Source = srv2\\pupils; Initial Catalog = MyShop330683525; Integrated Security = True; Trust Server Certificate=True"));
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
