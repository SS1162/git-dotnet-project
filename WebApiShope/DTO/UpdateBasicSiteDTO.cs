using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record UpdateBasicSiteDTO
    (
        [Required]
         int BasicSiteID ,
        [Required]
         string SiteName ,
         string UserDescreption ,
         [Required]
         int SiteTypeID ,
         [Required]
         int PlatformID 
    );
}
