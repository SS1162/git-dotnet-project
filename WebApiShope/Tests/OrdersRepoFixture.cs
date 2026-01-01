using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace Tests
{
 
    public class OrderRepoFixture : IDisposable
    {
        public List<Order> OrdersList { get; private set; }

        public List<OrdersItem> OrderItemsList { get; private set; }
        public Mock<DbSet<Order>> MockSet { get; private set; }
        public Mock<MyShop330683525Context> MockContext { get; private set; }

        public OrderRepoFixture()
        {
            MockContext = new Mock<MyShop330683525Context>();
            // 1. אתחול נתונים ראשוניים לבדיקות
            OrdersList = new List<Order>
        {
            new Order
            {
                OrderId = 1,
                OrderDate = new DateOnly(2023, 10, 1),
                OrderSum = 150.5,
                UserId = 101,
                FinalPrompt = "First Order Prompt"
            },
            new Order
            {
                OrderId = 2,
                OrderDate = new DateOnly(2023, 10, 5),
                OrderSum = 300.0,
                UserId = 102,
                FinalPrompt = "Second Order Prompt"
            }


        };


            // יצירת נתונים לדוגמה עבור פריטי הזמנה
            OrderItemsList = new List<OrdersItem>
{
    new OrdersItem
    {
        OrderItemId = 1,
        OrderId = 1,  // מקושר להזמנה הראשונה שלך
        ProductsId = 50,
        UserDescription = "High quality logo",
        BasicSitesPlatforms = 1
    },
    new OrdersItem
    {
        OrderItemId = 2,
        OrderId = 1,  // גם שייך להזמנה 1
        ProductsId = 51,
        UserDescription = "Mobile version",
        BasicSitesPlatforms = 1
    },
    new OrdersItem
    {
        OrderItemId = 3,
        OrderId = 2,  // מקושר להזמנה השנייה שלך
        ProductsId = 55,
        UserDescription = "SEO Optimization",
        BasicSitesPlatforms = 2
    }
};

            // חיבור הרשימה ל-Mock של ה-Context
            MockContext.Setup(c => c.OrdersItems).ReturnsDbSet(OrderItemsList);

            

            // 2. הגדרת ה-DbSet עבור השליפות (Get)
            MockContext.Setup(c => c.Orders).ReturnsDbSet(OrdersList);

            // שליפת ה-Mock של ה-DbSet עצמו כדי להגדיר לו התנהגויות נוספות
            MockSet = Mock.Get(MockContext.Object.Orders);

          
        }

        public void Dispose()
        {
            // ניקוי משאבים בין טסט לטסט
            OrdersList.Clear();
            MockContext.Invocations.Clear();
            MockContext.Reset();
        }
    }
}
