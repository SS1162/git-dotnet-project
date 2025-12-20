using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  record AddToCartDTO
    {
        public int UserID { get; set; }
        public int ProductsID { get; set; }
        public string UserDescription { get; set; }
        public int PlatformsID { get; set; }

    }
}
