using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public record BasicSiteDTO
    {
        public int BasicSiteID { get; set; }
        public string SiteName { get; set; }
        public string UserDescreption { get; set; }
        public string PlatformName { get; set; }

        public string SiteTypeName { get; set; }

        public int PlatformID { get; set; }

        public int SiteTypeID { get; set; }
        public string SiteTypeDescreption { get; set; }
    }
}
