using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrdersRepositoriy : IOrdersRepositoriy
    {



        MyShop330683525Context _MyShop330683525Context;

        public OrdersRepositoriy(MyShop330683525Context _MyShop330683525Context)
        {
            this._MyShop330683525Context = _MyShop330683525Context;
        }


        async public Task<Order> AddOrdersRepositories(Order order)
        {
            await _MyShop330683525Context.Orders.AddAsync(order);

            await _MyShop330683525Context.SaveChangesAsync();
            return order;
        }



        async public Task<Order?> ReturnOrderByIdRepositories(int id)
        {
            return await _MyShop330683525Context.Orders.FindAsync(Convert.ToInt16(id));
        }


    }
}
