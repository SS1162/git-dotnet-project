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


        ICartsReposetory _cartsReposetory;
        IUsersReposetory _usersReposetory;
        IMapper _mapper;
        IProductsReposetory _productsReposetory;
        IPlatformsReposetory _platformsReposetory;
        public CartItemServise(ICartsReposetory cartsReposetory, IMapper mapper, IUsersReposetory usersReposetory, IProductsReposetory productsReposetory, IPlatformsReposetory platformsReposetory)
        {
            this._cartsReposetory = cartsReposetory;
            this._mapper = mapper;
            this._usersReposetory = usersReposetory;
            this._productsReposetory = productsReposetory;
            this._platformsReposetory = platformsReposetory;

        }
        public async Task<CartItemDTO?> GetByIdServise(int id)
        {
            CartItem? cartItem = await _cartsReposetory.GetByIdReposetory(id);
            return _mapper.Map<CartItemDTO>(cartItem);
        }
        public async Task<Resulte<IEnumerable<CartItemDTO>>> GetUserCartServise(int userId)
        {
            User? checkIfUserInsist = await _usersReposetory.GetByIDUsersRepositories(userId);
            if (checkIfUserInsist == null)
            {
                return Resulte<IEnumerable<CartItemDTO>>.Failure("The user ID isn't insist");
            }
            var cartItems = await _cartsReposetory.GetByIDUserCartItemsReposetory(userId);
            return Resulte<IEnumerable<CartItemDTO>>.Success(_mapper.Map<IEnumerable<CartItemDTO>>(cartItems));
        }

        public async Task<Resulte<CartItemDTO>> CreateUserCartServise(AddToCartDTO dto)
        {


            User? checkIfUserInsist = await _usersReposetory.GetByIDUsersRepositories(dto.UserID);
            if (checkIfUserInsist == null)
            {
                return Resulte<CartItemDTO>.Failure("The user ID isn't insist");
            }

            Product? checkIfProductInsist = await _productsReposetory.GetByIDProductsReposetory(dto.ProductsID);
            if (checkIfProductInsist == null)
            {
                return Resulte<CartItemDTO>.Failure("The product ID isn't insist");
            }
            if (checkIfProductInsist.ProductsName == "Empty" && dto.UserDescription == null)
            {
                return Resulte<CartItemDTO>.Failure("The product is empty so you must add user description");
            }
            if (checkIfProductInsist.ProductsName != "Empty" && dto.UserDescription != null)
            {
                return Resulte<CartItemDTO>.Failure("The product isn't empty so you musn't add user description");
            }
            Platform? checkIfPlatformInsist = await _platformsReposetory.GetByIDPlatformsReposetory(dto.PlatformsID);
            if (checkIfPlatformInsist == null)
            {
                return Resulte<CartItemDTO>.Failure("The platform ID isn't insist");
            }

            CartItem? existing = await _cartsReposetory.GetByUserAndProductIdReposetory(dto.UserID, dto.ProductsID);
            if (existing != null)
            {
                return Resulte<CartItemDTO>.Failure("Cart item already exists for this user and product.");
            }

            CartItem cartItem = _mapper.Map<CartItem>(dto);
            CartItem created = await _cartsReposetory.CreateUserCartReposetory(cartItem);

            return Resulte<CartItemDTO>.Success(_mapper.Map<CartItemDTO>(created));
        }

        public async Task<Resulte<CartItemDTO?>> ChangeProductToNotValidCartServise(int cartItemId)
        {
            CartItem? checkIfIDinsist = await _cartsReposetory.GetByIdReposetory(cartItemId);
            if (checkIfIDinsist == null)
            {
                return Resulte<CartItemDTO?>.Failure("the cart item id not insist");
            }
            if (checkIfIDinsist.Valid == 0)
            {
                return Resulte<CartItemDTO?>.Failure("the product isn't valid alredy");
            }
            await _cartsReposetory.ChangeProductToNotValidReposetory(cartItemId);
            return Resulte<CartItemDTO>.Success(null);

        }

        public async Task<Resulte<CartItemDTO?>> ChangeProductToValidCartServise(int cartItemId)
        {
            CartItem? checkIfIDinsist = await _cartsReposetory.GetByIdReposetory(cartItemId);
            if (checkIfIDinsist == null)
            {
                return Resulte<CartItemDTO?>.Failure("the cart item id not insist");
            }
            if (checkIfIDinsist.Valid == 1)
            {
                return Resulte<CartItemDTO?>.Failure("the product is valid alredy");
            }
            await _cartsReposetory.ChangeProductToNotValidReposetory(cartItemId);
            return Resulte<CartItemDTO>.Success(null);
        }

        public async Task<Resulte<CartItemDTO?>> DeleteUserCartServise(int cartItemId)
        {

            CartItem? checkIfIDinsist = await _cartsReposetory.GetByIdReposetory(cartItemId);
            if (checkIfIDinsist == null)
            {
                return Resulte<CartItemDTO?>.Failure("the cart item id not insist");
            }
            await _cartsReposetory.DeleteUserCartReposetory(cartItemId);
            return Resulte<CartItemDTO?>.Success(null);

        }
    }



}
