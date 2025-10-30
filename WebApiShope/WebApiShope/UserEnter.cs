using System.ComponentModel.DataAnnotations;

namespace WebApiShope
{
    public class LoginUser
    {

        public int UserID { get; set; }
        [EmailAddress]
        public string UserName { get; set; }
        public string UserPassward { get; set; }

       

        
    }
}