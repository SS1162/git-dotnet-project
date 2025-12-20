using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepositoriesUsers, RepositoriesUsers>();

builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<IPasswordsService,PasswordsService>();

builder.Services.AddScoped<IPlatformsReposetory, PlatformsReposetory>();

builder.Services.AddScoped<IPlatformsServise, PlatformsServise>();

builder.Services.AddScoped<IProductsReposetory, ProductsReposetory>();


builder.Services.AddScoped<IMainCategoriesServise, MainCategoriesServise>();

builder.Services.AddScoped<IMainCategoryReposetory, MainCategoryReposetory>();

builder.Services.AddScoped<ICategoriesServise, CategoriesServise>();


builder.Services.AddScoped<ICategoriesReposetory, CategoriesReposetory>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<MyShop330683525Context>(option => option.UseSqlServer
("Data Source=DESKTOP-R5RADSP;Initial Catalog=MyPromptShop;Integrated Security=True;Trust Server Certificate=True"));

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
