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

        IProductsReposetory _IProductsReposetory;
        IMapper _Imapper;
        public ProductsServise(IProductsReposetory _IProductsReposetory,
        IMapper _Imapper)
        {
            this._IProductsReposetory = _IProductsReposetory;
            this._Imapper = _Imapper;
        }

        async public Task<IEnumerable<ProductDTO>> GetProductsServise(int categoryID)
        {

            List<Product> productsFromReposetory = (List<Product>)await _IProductsReposetory.GetProductsReposetory(categoryID);
            return _Imapper.Map<List<ProductDTO>>(productsFromReposetory);
        }

        async public Task UpdateProductServise(int id, UpdateProductDTO productToUpdate)
        {
            Product productToReposetory = _Imapper.Map<Product>(productToUpdate);
            //למלא פרומפט עם gemini
            productToReposetory.ProductPrompt = "vfsghhfg";
            await _IProductsReposetory.UpdateProductsReposetory(id, productToReposetory);

        }


        async public Task<ProductDTO> AddProductServise(AddProductDTO productToUpdate)
        {
            Product productToReposetory = _Imapper.Map<Product>(productToUpdate);
            //למלא פרומפט עם gemini
            productToReposetory.ProductPrompt = "gfasdfghfh";
            Product productFromReposetory = await _IProductsReposetory.AddProductsReposetory(productToReposetory);

            return _Imapper.Map<ProductDTO>(productFromReposetory);
        }
        async public Task<bool> DeleteIDProductServise(int id)
        {

            return await _IProductsReposetory.DeleteProductsReposetory(id);
        }
    }
}
