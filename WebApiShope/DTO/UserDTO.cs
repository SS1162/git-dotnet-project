using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record UserDTO
    {
        [Required]
        public string UserID { get; set; }

        [EmailAddress]
        [Required]
        public string UserName { get; set; }
 
        public string FirstName { get; set; }


        public string LastName { get; set; }

        [Phone]
        public string Phone { get; set; }

    }
}
