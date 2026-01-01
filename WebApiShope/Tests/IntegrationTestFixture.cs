using Microsoft.EntityFrameworkCore;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ShopIntegrationFixture : IDisposable
    {
        public MyShop330683525Context Context { get; private set; }
        private readonly DbContextOptions<MyShop330683525Context> _options;

        public ShopIntegrationFixture()
        {
            // הגדרת שם ייחודי למניעת התנגשויות בין הרצות שונות בשרת ה-CI/CD
            _options = new DbContextOptionsBuilder<MyShop330683525Context>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            CreateNewContext();
        }

        public void CreateNewContext()
        {
            Context?.Dispose();
            Context = new MyShop330683525Context(_options);

            // Hook: מנקה הכל ובונה מחדש את הסכמה (Code First)
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            // 1. הוספת MainCategory
            // נתוני Seed עבור MainCategory
            Context.MainCategories.AddRange(
                new MainCategory { MainCategoryId = 1, MainCategoryName = "מוצרי חשמל", MainCategoryPrompt = "Electronics" },
                new MainCategory { MainCategoryId = 2, MainCategoryName = "ביגוד", MainCategoryPrompt = "Clothing" }
            );
            Context.SaveChanges();

            // נתונים התואמים לטסטים שלך
            Context.Categories.AddRange(
                new Category { CategoryId = 1, MainCategoryId = 1, CategoryName = "מחשבים ניידים", CategoryDescreption = "מחשבים חזקים", CategoryPrompt = ".." },
                new Category { CategoryId = 2, MainCategoryId = 1, CategoryName = "מקלדות", CategoryDescreption = "ציוד היקפי", CategoryPrompt = ".." }
            );
            Context.SaveChanges();

            // 3. הוספת Product
            var product = new Product
            {
                ProductsId = 1,
                CategoryId = 1,
                ProductsName = "Macbook Pro",
                Price = 2500,
                ProductPrompt = "Apple laptop"
            };
            Context.Products.Add(product);

            // 4. הוספת User
            Context.Users.AddRange(
           new User { UserId = 1, UserName = "admin1", Password = "p1", FirstName = "Admin", LastName = "User" },
           new User { UserId = 2, UserName = "user2", Password = "p2", FirstName = "Test", LastName = "User" }
       );
            Context.SaveChanges();

            // 5. הוספת סטטוסים בסיסיים
            Context.Statuses.AddRange(
                new Status { StatusId = 1, StatusName = "Pending" },
                new Status { StatusId = 2, StatusName = "Completed" }
            );

            // 6. הוספת פלטפורמה (לצורך ה-Foreign Keys ב-OrderItems)
            var platform = new Platform { PlatformId = 1, PlatformName = "Web", PlatformsPrompt = "Web platform" };
            Context.Platforms.Add(platform);

            Context.SaveChanges();


            var basicSite = new BasicSite
            {
                BasicSiteId = 1,
                SiteName = "My Shop",
                UserDescreption = "General eCommerce Site",
                BasicSitesPlatforms = 1 // מקשר לפלטפורמה שיצרנו בשלב 6
            };
            Context.BasicSites.Add(basicSite);
            Context.SaveChanges();

            // 8. הוספת Order (לצורך טסטים של שליפה ועדכון)
            var order = new Order
            {
                OrderId = 1,
                UserId = 1,
                BasicId = 1,
                OrderSum = 150.5,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                StatusId = 1,
                FinalPrompt = "Sample Order"
            };
            Context.Orders.Add(order);
            Context.SaveChanges();

            // 9. הוספת OrdersItem (לצורך טסטים של פריטי הזמנה)
            Context.OrdersItems.Add(new OrdersItem
            {
                OrderId = 1,
                ProductsId = 1,
                BasicSitesPlatforms = 1,
                UserDescription = "High quality logo"
            });

            Context.SaveChanges();
        }
        public void ResetDatabase()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }
        public void Dispose()
        {
            Context?.Database.EnsureDeleted();
            Context?.Dispose();
        }
    }
}