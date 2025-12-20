using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public record AddCategoryDTO
    {
        [Required]
        public int MainCategoryID { get; set; }
        [Required]

        public string CategoryName { get; set; }
        [Required]

        public string ImgUrl { get; set; }
        [Required]
        public string CategoryDescreption { get; set; }
    }
}
