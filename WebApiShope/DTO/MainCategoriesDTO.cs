using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record MainCategoriesDTO
    {
        public int MainCategoryID { get; set; }

        public string MainCategoryName { get; set; }
    }
}
