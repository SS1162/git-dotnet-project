using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record Orders
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public float OrderSum { get; set; }

        [Required]
        public int BasicID { get; set; }

        [Required]
        public List<AddToCartDTO> Products { get; set; }
    }
}
