using System.ComponentModel.DataAnnotations;

namespace WebApiShope
{
    public class Users
    {
        //[Required]
        public int UserID { get; set; }
        
        public string UserName { get; set; }
        public string UserPassward { get; set; }
         [EmailAddress]
        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }
    }
}
