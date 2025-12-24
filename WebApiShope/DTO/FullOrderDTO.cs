using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record FullOrderDTO
      (
         [Required]
         int OrderID, 
        [Required]
         int UserID,

        [Required]
         float OrderSum,

        [Required]
         int BasicID,

         [Required]
         int Status,

        [Required]
         List<AddToCartDTO> Products
        );
}
