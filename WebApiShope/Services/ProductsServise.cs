using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using Entities;
namespace Services
{
    public class ProductsServise : IProductsServise
    {

        IProductsReposetory _productsReposetory;
        IMapper _mapper;
        ICategoriesReposetory _categoriesReposetory;
        public ProductsServise(IProductsReposetory productsReposetory,
        IMapper mapper, ICategoriesReposetory categoriesReposetory)
        {
            this._productsReposetory = productsReposetory;
            this._mapper = mapper;
            this._categoriesReposetory= categoriesReposetory;
        }

        async public Task<Resulte<ResponePage<ProductDTO>>> GetProductsServise(int categoryID, int numOfPages, int PageSize, string? search, int? minPrice, int? MaxPrice, bool? orderByPrice, bool? desc)
        {

            
            if (orderByPrice==null&&desc!=null)
            {
                return Resulte<ResponePage<ProductDTO>>.Failure("You can't add desc without orderBy");
            }
            if(minPrice>MaxPrice)
            {
                return Resulte<ResponePage<ProductDTO>>.Failure("Min price is bigger then max price");
            }

            if(PageSize>50)
            {
                return Resulte<ResponePage<ProductDTO>>.Failure("Page size is too big");
            }

            Category? toCheckIfCategotyInsist = await _categoriesReposetory.GetByIDCategoriesReposetory(categoryID);
            if(toCheckIfCategotyInsist==null)
            {
                return Resulte<ResponePage<ProductDTO>>.Failure("Category ID is not insist");
            }

            (IEnumerable<Product>, int) responeFromReposetory = await _productsReposetory.GetProductsReposetory(categoryID, numOfPages, PageSize, search, minPrice, MaxPrice, orderByPrice, desc);
    
            ResponePage<ProductDTO> responeForClient = new ResponePage<ProductDTO>();

            responeForClient.CurrentPage = numOfPages;
            responeForClient.PageSize = PageSize;

            responeForClient.HasPreviousPage = numOfPages > 0;
            responeForClient.HasNextPage = (numOfPages - 1) * PageSize < responeFromReposetory.Item2;
     
            responeForClient.TotalItems= responeFromReposetory.Item2;
            responeForClient.Data = _mapper.Map<IEnumerable<ProductDTO>>(responeFromReposetory.Item1);


            return Resulte<ResponePage<ProductDTO>>.Success(responeForClient);
        }

        async public Task UpdateProductServise(int id, UpdateProductDTO productToUpdate)
        {
            Product productToReposetory = _mapper.Map<Product>(productToUpdate);
            //למלא פרומפט עם gemini
            productToReposetory.ProductPrompt = "vfsghhfg";
            await _productsReposetory.UpdateProductsReposetory(id, productToReposetory);

        }


        async public Task<ProductDTO> AddProductServise(AddProductDTO productToUpdate)
        {
            Product productToReposetory = _mapper.Map<Product>(productToUpdate);
            //למלא פרומפט עם gemini
            productToReposetory.ProductPrompt = "gfasdfghfh";
            Product productFromReposetory = await _productsReposetory.AddProductsReposetory(productToReposetory);

            return _mapper.Map<ProductDTO>(productFromReposetory);
        }
        async public Task<bool> DeleteIDProductServise(int id)
        {

            return await _productsReposetory.DeleteProductsReposetory(id);
        }
    }
}
