using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record OrdersDTO
    (
        [Required]
         int UserID,

        [Required]
         float OrderSum,

        [Required]
         int BasicID,

        [Required]
         List<AddToCartDTO> Products
        );
}
