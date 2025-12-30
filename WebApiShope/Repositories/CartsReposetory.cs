using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repositories
{
    public class CartsReposetory : ICartsReposetory
    {

        MyShop330683525Context _DBcontext;

        public CartsReposetory(MyShop330683525Context _DBcontext)
        {
            this._DBcontext = _DBcontext;
        }

        public async Task<IEnumerable<CartItem>> GetByIDUserCartItemsReposetory(int Id)
        {
            return await _DBcontext.CartItems
                .Where(ci => ci.UserId == Id)
                .ToListAsync();
        }

        public async Task<CartItem> CreateUserCartReposetory(CartItem cartItem)
        {
            await _DBcontext.CartItems.AddAsync(cartItem);
            await _DBcontext.SaveChangesAsync();
            return cartItem;
        }

        public async Task UpdateUserCartReposetory(CartItem cartItem)
        {
            _DBcontext.CartItems.Update(cartItem);
            await _DBcontext.SaveChangesAsync();

        }

        public async Task ChangeProductToValidReposetory(int Id, CartItem cartItem)
        {
            cartItem.Valid = 1;
            _DBcontext.CartItems.Update(cartItem);
            await _DBcontext.SaveChangesAsync();

        }


        public async Task ChangeProductToNotValidReposetory(int Id, CartItem cartItem)
        {
            cartItem.Valid = 0;
            _DBcontext.CartItems.Update(cartItem);
            await _DBcontext.SaveChangesAsync();

        }
        //       מוחקת סל ומוסיפה הזמנות
        public async Task DeleteUserCartReposetory(int userID)
        {
            List<CartItem> itemList = await _DBcontext.CartItems.Where(x => x.UserId == userID).ToListAsync();
            for (int i = 0; i < itemList.Count(); i++)
            {

                _DBcontext.CartItems.Remove(itemList[i]);
            }
            await _DBcontext.SaveChangesAsync();
        }
        public async Task<bool> DeleteUserCartItemReposetory(int Id)
        {
            var cartItemsObjectToDelete = await _DBcontext.CartItems.FirstOrDefaultAsync(x => x.CartId == Id);

            if (cartItemsObjectToDelete == null)
                return false;
            _DBcontext.CartItems.Remove(cartItemsObjectToDelete);
            await _DBcontext.SaveChangesAsync();
            return true;
        }

        public async Task<CartItem?> GetByUserAndProductIdReposetory(int userId, int productId)
        {
            return await _DBcontext.CartItems.FirstOrDefaultAsync(c => c.UserId == userId && c.ProductsId == productId);
        }

        public async Task<CartItem?> GetByIdReposetory(int id)
        {
            return await _DBcontext.CartItems.FirstOrDefaultAsync(c => c.CartId == id);
        }
    }
}
