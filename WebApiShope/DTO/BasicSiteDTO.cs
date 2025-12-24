using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public record BasicSiteDTO
    (
        int BasicSiteID ,
        string SiteName ,
        string UserDescreption ,
        string PlatformName ,

        string SiteTypeName ,

        int PlatformID ,

        int SiteTypeID ,
         string SiteTypeDescreption 
    );
}
