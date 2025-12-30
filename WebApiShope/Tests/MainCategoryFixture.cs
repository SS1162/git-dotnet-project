using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore; // החבילה שמאפשרת את ReturnsDbSet
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Repositories;

public class MainCategoryRepoFixture : IDisposable
{
    public List<MainCategory> MainCategoriesList { get; private set; }
    public Mock<DbSet<MainCategory>> MockSet { get; private set; }
    public Mock<MyShop330683525Context> MockContext { get; private set; }

    public MainCategoryRepoFixture()
    {
        // 1. אתחול נתוני דמו
        MainCategoriesList = new List<MainCategory>
        {
            new MainCategory
            {
                MainCategoryId = 1,
                MainCategoryName = "מוצרי חשמל",
                MainCategoryPrompt = "Electrical Appliances",
                Categories = new List<Category>()
            },
            new MainCategory
            {
                MainCategoryId = 2,
                MainCategoryName = "ביגוד",
                MainCategoryPrompt = "Clothing",
                Categories = new List<Category>()
            }
        };

        // 2. יצירת ה-Mock ל-Context
        MockContext = new Mock<MyShop330683525Context>();

        // 3. שימוש בסינטקס הנקי - הזרקת הרשימה ל-DbSet
        // זה מחליף את ה-Setup הידני, את ה-FindAsync ואת ה-AddAsync
        MockContext.Setup(c => c.MainCategories).ReturnsDbSet(MainCategoriesList);

        // 4. חילוץ ה-MockSet כדי שלא נצטרך לשנות את ה-Tests
        // הפעולה הזו מחברת את ה-MockSet הישן למימוש שנוצר ב-ReturnsDbSet
        MockSet = Mock.Get(MockContext.Object.MainCategories);

        // 5. הגדרת SaveChangesAsync כסטנדרט
        MockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);
    }

    public void Dispose()
    {
        // איפוס וניקוי
        MainCategoriesList.Clear();
        MockContext.Invocations.Clear();
        if (MockSet != null) MockSet.Invocations.Clear();
    }
}