using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  record AddToCartDTO
    (
         int UserID ,
        int ProductsID,
        string UserDescription ,
        int PlatformsID 

    );
}
