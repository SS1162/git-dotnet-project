using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record ProductDTO
    (
         int ProductsID ,
         int CategoryID ,
         string ProductsName ,
         string CategoryName ,
         string ImgUrl ,
         float Price 

);

            

    
}
