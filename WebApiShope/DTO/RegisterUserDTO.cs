using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public record RegisterUserDTO
    (
        [EmailAddress]
        [Required]
         string UserName ,
        [Required]
         string UserPassward ,

       
         string FirstName ,


         string LastName ,

        [Phone]
         string Phone 

   );
}
