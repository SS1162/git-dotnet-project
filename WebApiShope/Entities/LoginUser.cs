using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   
    public class LoginUser
    {

        public int UserID { get; set; }
        [EmailAddress]
        public string UserName { get; set; }
        public string UserPassward { get; set; }




    }
}
