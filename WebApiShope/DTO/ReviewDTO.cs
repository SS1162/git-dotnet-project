using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record ReviewDTO(
        [Required]
        int ReviewId,
        [Required]
        int OrderId,
        [Required]
        int Score,
        string Note,
        string ReviewImageUrl
    );
}
