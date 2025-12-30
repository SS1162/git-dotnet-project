using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class OrderIntegrationFixture : IDisposable
    {
        public MyShop330683525Context Context { get; private set; }
        private readonly DbContextOptions<MyShop330683525Context> _options;

        public OrderIntegrationFixture()
        {
            // 1. הגדרת האופציות פעם אחת עבור ה-Fixture
            _options = new DbContextOptionsBuilder<MyShop330683525Context>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // 2. יצירת ה-Context הראשון
            CreateNewContext();
        }

        public void CreateNewContext()
        {
            // ניקוי אם קיים Context קודם
            Context?.Dispose();

            Context = new MyShop330683525Context(_options);

            // מחיקה ובנייה מחדש של ה-Database (מבטיח ניקיון טוטאלי)
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            // הכנסת נתונים (Seeding)
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            Context.Orders.AddRange(new List<Order>
            {
                new Order { OrderId = 1, OrderSum = 150.5, UserId = 101 },
                new Order { OrderId = 2, OrderSum = 300.0, UserId = 102 }
            });

            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Database.EnsureDeleted();
            Context?.Dispose();
        }
    }
}
