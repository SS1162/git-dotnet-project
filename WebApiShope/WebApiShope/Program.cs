using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepositoriesUsers, RepositoriesUsers>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IPasswordService,PasswordService>();
builder.Services.AddScoped<ICategoriesRepositoriy, CategoriesRepositoriy>();

builder.Services.AddScoped<ICategoriesService, CategoriesService>();

builder.Services.AddScoped<IOrdersRepositoriy, OrdersRepositoriy>();

builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IProductsRepositoriy, ProductsRepositoriy>();

builder.Services.AddScoped<IProductsService, ProductsService>();



builder.Services.AddDbContext<MyShop330683525Context>(option => option.UseSqlServer
("Data Source=srv2\\pupils;Initial Catalog=MyShopShany2026;Integrated Security=True;Trust Server Certificate=True"));
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
