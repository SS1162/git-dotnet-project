using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public record RegisterUserDTO
    {
        [EmailAddress]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassward { get; set; }

       
        public string FirstName { get; set; }


        public string LastName { get; set; }

        [Phone]
        public string Phone { get; set; }

    }
}
