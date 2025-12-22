using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record AddBasicSiteDTO
    {
        public string SiteName { get; set; }
        public string UserDescreption { get; set; }
        public int SiteTypeID { get; set; }
        public int PlatformID { get; set; }

    }
}
