using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  record UserOrdersDTO
    (
         int UserID,

         int OrderID ,
         DateTime OrderDate ,
         float OrderSum ,
         string SiteName ,
         string SiteTypeName ,
         string SiteTypeDescreption ,
         string StatusName ,
         PlatformsDTO PlatformName ,
         int LenOrderItems ,
         string ReviewID ,
         float Stars ,
         string ReviewImg 
    );
}
