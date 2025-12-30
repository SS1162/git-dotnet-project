using AutoMapper;
using DTO;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.CartItemServise;

namespace Services
{
    public class CartItemServise : ICartItemServise
    {


        ICartsReposetory _CartsReposetory;
        IMapper _mapper;

        public CartItemServise(ICartsReposetory _CartsReposetory, IMapper _mapper)
        {
            this._CartsReposetory = _CartsReposetory;
            this._mapper = _mapper;
        }
        public async Task<CartItemDTO?> GetByIdServise(int id)
        {
            CartItem cartItem = await _CartsReposetory.GetByIdReposetory(id);


            return _mapper.Map<CartItemDTO>(cartItem);
        }
        public async Task<IEnumerable<CartItemDTO>?> GetUserCartServise(int userId)
        {
            var cartItems = await _CartsReposetory.GetByIDUserCartItemsReposetory(userId);


            return _mapper.Map<IEnumerable<CartItemDTO>>(cartItems);
        }

        public async Task<CartItemDTO> CreateUserCartServise(AddToCartDTO dto)
        {
            CartItem? existing = await _CartsReposetory.GetByUserAndProductIdReposetory(dto.UserID, dto.ProductsID);
            if (existing != null)
                throw new Exception("Cart item already exists for this user and product.");

            CartItem cartItem = _mapper.Map<CartItem>(dto);
            CartItem created = await _CartsReposetory.CreateUserCartReposetory(cartItem);

            return _mapper.Map<CartItemDTO>(created);
        }

        //לא עשיתי אותו עדיין זה רק מעטפת כדי שלא יעשה טעות בקולנטרולר
        public async Task<CartItemDTO> UpdateUserCartServise(CartItemDTO dto)
        {
            return dto;
        }

        public async Task<bool> DeleteUserCartServise(int cartItemId)
        {
            return await _CartsReposetory.DeleteUserCartReposetory(cartItemId);

        }
    }



}
