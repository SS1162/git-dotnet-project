using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record SiteTypeDTO
    {
        public int SiteTypeID { get; set; }

        public string SiteTypeName { get; set; }



        public string SiteTypeDescreption { get; set; }
        public float Price { get; set; }
       

    }
}
