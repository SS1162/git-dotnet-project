using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Repositories;
using Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepositoriesUsers, RepositoriesUsers>();

builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<IPasswordsService,PasswordsService>();

builder.Services.AddScoped<IPlatformsRepository, PlatformsRepository>();

builder.Services.AddScoped<IPlatformsService, PlatformsService>();

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();


builder.Services.AddScoped<IReviewsService, ReviewsService>();

builder.Services.AddScoped<ISiteTypesRepository, SiteTypesRepository>();
builder.Services.AddScoped<ICartsRepository, CartsRepository>();

builder.Services.AddScoped<IOrdersService, OrdersService>();

builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();


builder.Services.AddScoped<IReviewsRepository, ReviewsRepository>();

builder.Services.AddScoped<IBasicSitesService, BasicSitesService>();


builder.Services.AddScoped<ISiteTypesService, SiteTypesService>();


builder.Services.AddScoped<IBasicSitesRepository, BasicSitesRepository>();


builder.Services.AddScoped<IMainCategoriesService, MainCategoriesService>();

builder.Services.AddScoped<IMainCategoryRepository, MainCategoryRepository>();

builder.Services.AddScoped<ICategoriesService, CategoriesService>();


builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();

builder.Services.AddScoped<IProductsService, ProductsService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<MyShop330683525Context>(option => option.UseSqlServer
("Data Source=DESKTOP-R5RADSP;Initial Catalog=MyPromptShop;Integrated Security=True;Trust Server Certificate=True"));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Host.UseNLog();
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
