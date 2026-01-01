
using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore; // החבילה שמאפשרת את ReturnsDbSet
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class UserRepoFixture : IDisposable
{
    private readonly List<User> _initialData = new List<User>
    {
        new User { UserId = 1, UserName = "Admin1", Password = "p1", FirstName = "A", LastName = "B", Phone = "0501111111" },
        new User { UserId = 2, UserName = "DevUser", Password = "p2", FirstName = "C", LastName = "D", Phone = "0522222222" }
    };

    public List<User> UsersList { get; private set; }

    // בסינטקס הזה, לרוב לא צריך Mock נפרד ל-Set, אבל נשאיר אותו בשביל תאימות לטסטים
    public Mock<DbSet<User>> MockSet { get; private set; }
    public Mock<MyShop330683525Context> MockContext { get; private set; }

    public UserRepoFixture()
    {
        // 1. אתחול הנתונים
        UsersList = new List<User>(_initialData);

        // 2. יצירת ה-Mock ל-Context
        MockContext = new Mock<MyShop330683525Context>();

        // 3. שימוש בסינטקס שביקשת - הזרקת הרשימה ישירות לתוך ה-Context
        // זה מטפל אוטומטית ב-Async ובחיבור ל-UsersList
        MockContext.Setup(x => x.Users).ReturnsDbSet(UsersList);

        // 4. לצורך תאימות לטסטים שמשתמשים ב-MockSet:
        // אנחנו מחלצים את ה-Mock של ה-DbSet שנוצר מאחורי הקלעים
        MockSet = Mock.Get(MockContext.Object.Users);

        // 5. הגדרת SaveChangesAsync
        MockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
                   .ReturnsAsync(1);
    }

    public void Dispose()
    {
        UsersList.Clear();
        MockContext.Invocations.Clear();
        // הערה: בסינטקס הזה הניקוי של MockSet יקרה דרך ה-Context
    }
}