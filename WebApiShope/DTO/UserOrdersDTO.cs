using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  record UserOrdersDTO
    {
        public int UserID{ get; set; }

        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderSum { get; set; }
        public string SiteName { get; set; }
        public string SiteTypeName { get; set; }
        public string SiteTypeDescreption { get; set; }
        public string StatusName { get; set; }
        public PlatformsDTO PlatformName { get; set; }
        public int LenOrderItems { get; set; }
        public string ReviewID { get; set; }
        public float Stars { get; set; }
        public string ReviewImg { get; set; }




    }
}
