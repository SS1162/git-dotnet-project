using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record CartItemDTO
    {
        public int CartID { get; set; }

        public string ProductsName { get; set; }

        public float Price { get; set; }

        public string CategoryName { get; set; }

        public string ImgUrl { get; set; }

        public string CategoryDescreption { get; set; }

        
        public int Valid { get; set; }

        public string UserDescription { get; set; }

        public string PlatformName { get; set; }

    }   
}
