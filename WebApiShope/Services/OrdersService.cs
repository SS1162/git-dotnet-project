using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrdersService : IOrdersService
    {




        private IOrdersRepositoriy iordersRepositoriy;
        public OrdersService(IOrdersRepositoriy iordersRepositoriy)
        {
            this.iordersRepositoriy = iordersRepositoriy;
        }


        async public Task<Order> AddOrdersService(Order order)
        {
            return await iordersRepositoriy.AddOrdersRepositories(order);
        }



        async public Task<Order?> ReturnOrderByIdService(int id)
        {
            return await iordersRepositoriy.ReturnOrderByIdRepositories(id);
        }


    }
}
