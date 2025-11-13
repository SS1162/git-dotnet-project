using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Users
    {
        //[Required]
        public int UserID { get; set; }
        [EmailAddress]
        public string UserName { get; set; }
        public string UserPassward { get; set; }
        
        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }
    }
}
