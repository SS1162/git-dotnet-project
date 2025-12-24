using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record AddBasicSiteDTO
    (
     string SiteName,
    string UserDescreption,
     int SiteTypeID,
     int PlatformID
);
    
}
