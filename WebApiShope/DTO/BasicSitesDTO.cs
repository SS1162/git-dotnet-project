using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record BasicSitesDTO
    {
        public string SiteName { get; set; }
        public string UserDescreption { get; set; }
        public int SiteTypeID { get; set; }
        public string PlatformName { get; set; }


    }
}
