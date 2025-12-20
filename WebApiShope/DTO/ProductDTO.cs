using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record ProductDTO
    {
        public int ProductsID { get; set; }
        public int CategoryID { get; set; }
        public string ProductsName { get; set; }
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }
        public float Price { get; set; }



            

    }
}
