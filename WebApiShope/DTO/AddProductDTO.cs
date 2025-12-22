using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record AddProductDTO
    {

       
        public int CategoryID { get; set; }
        public string ProductsName { get; set; }
   
        public float Price { get; set; }

    }
}
