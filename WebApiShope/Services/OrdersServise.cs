using AutoMapper;
using DTO;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrdersServise : IOrdersServise
    {

        IOrdersReposetory _OrderRepository;
        IMapper _mapper;


        public OrdersServise(IOrdersReposetory _OrderRepository, IMapper _mapper)
        {
            this._OrderRepository = _OrderRepository;
            this._mapper = _mapper;
        }

        public async Task<FullOrderDTO> GetByIdOrderServise(int id)
        {
            Order order = await _OrderRepository.GetOrderByIdReposetory(id);

            return _mapper.Map<FullOrderDTO>(order);
        }
        public async Task<FullOrderDTO> AddOrderServise(OrdersDTO dto)
        {
            Order orderToReposetory = _mapper.Map<Order>(dto);
            Order orderFromReposetory = await _OrderRepository.AddOrderReposetory(orderToReposetory);
            return _mapper.Map<FullOrderDTO>(orderFromReposetory);
        }
        public async Task UpdateStatusServise(int id , FullOrderDTO order)
        {
            Order orderToReposetory = _mapper.Map<Order>(order);
            await _OrderRepository.UpdateStatusReposetory(id,orderToReposetory);
        }

        public async Task<IEnumerable<OrderItemDTO>> GetOrderItemsServise(int orderId)
        {
            var orderItems = await _OrderRepository.GetOrderItemsReposetory(orderId);

            return _mapper.Map<IEnumerable<OrderItemDTO>>(orderItems);
        }
    }

}

