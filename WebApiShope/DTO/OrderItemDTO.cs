using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record OrderItemDTO
    {

        public int OrderItemID { get; set; }

        public string UserDescription { get; set; }

        public string PlatformName { get; set; }

        public int ProductsName { get; set; }

        public float Price { get; set; }

        public string CategoryName { get; set; }

        public string ImgUrl { get; set; }

        public string CategoryDescreption { get; set; }

    

    }
}
