using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record UpdateProductDTO
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductsName { get; set; }

        public float Price { get; set; }

    }
}
