using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore; // ודאי שחבילה זו מותקנת
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Repositories;
namespace Tests
{
    public class CategoryRepoFixture : IDisposable
    {
        public List<Category> CategoriesList { get; private set; }
        public Mock<DbSet<Category>> MockSet { get; private set; }
        public Mock<MyShop330683525Context> MockContext { get; private set; }

        public CategoryRepoFixture()
        {
            // 1. אתחול נתוני דמו לישות Category
            CategoriesList = new List<Category>
        {
            new Category
            {
                CategoryId = 1,
                MainCategoryId = 1,
                CategoryName = "מחשבים ניידים",
                CategoryPrompt = "Laptops",
                ImgUrl = "laptops.jpg",
                CategoryDescreption = "כל סוגי המחשבים הניידים",
                Products = new List<Product>()
            },
            new Category
            {
                CategoryId = 2,
                MainCategoryId = 1,
                CategoryName = "מסכים",
                CategoryPrompt = "Monitors",
                ImgUrl = "monitors.jpg",
                CategoryDescreption = "מסכי גיימינג ועבודה",
                Products = new List<Product>()
            }
        };

            // 2. יצירת ה-Mock ל-Context
            MockContext = new Mock<MyShop330683525Context>();

            // 3. שימוש בסינטקס הנקי - הזרקת הרשימה לתוך ה-DbSet
            // פעולה זו מטפלת אוטומטית ב-Async, FindAsync, ו-AddAsync
            MockContext.Setup(c => c.Categories).ReturnsDbSet(CategoriesList);



            // 4. חילוץ ה-MockSet עבור תאימות לטסטים קיימים
            MockSet = Mock.Get(MockContext.Object.Categories);

            // פנייה ישירה למשתני המחלקה בתוך ה-Fixture
            MockSet.Setup(m => m.AddAsync(It.IsAny<Category>(), It.IsAny<CancellationToken>()))
                .Callback<Category, CancellationToken>((category, token) =>
                {
                    CategoriesList.Add(category); // הוספה לרשימה המקומית של ה-Fixture
                })
                .ReturnsAsync((Category c, CancellationToken t) => (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Category>)null!);

            //// 5. הגדרת SaveChangesAsync שתמיד תחזיר הצלחה
            //MockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
            //    .ReturnsAsync(1);
        }

        public void Dispose()
        {
            // ניקוי משאבים בין טסטים
            CategoriesList.Clear();
            MockContext.Invocations.Clear();
            if (MockSet != null) MockSet.Invocations.Clear();

        }
    }
}