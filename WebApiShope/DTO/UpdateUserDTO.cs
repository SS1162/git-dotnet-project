using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record UpdateUserDTO
    {
        [Required]
        public short UserId { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        [Required]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
