using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SiteTypesRepository : ISiteTypesRepository
    {
        MyShop330683525Context _DBcontext;
        public SiteTypesRepository(MyShop330683525Context _DBcontext)
        {
            this._DBcontext = _DBcontext;
        }

        public async Task<IEnumerable<SiteType>?> GetAllSiteTypesReposetory()
        {
            return await _DBcontext.SiteTypes.ToListAsync();
        }
        public async Task<SiteType?> GetSiteTypeByIdReposetory(int id)
        {
            return await _DBcontext.SiteTypes.FirstOrDefaultAsync(u => u.SiteTypeId == id);
        }
        public async Task UpdateSiteTypeByMngReposetory(int id,SiteType siteType)
        {
            _DBcontext.SiteTypes.Update(siteType);
            await _DBcontext.SaveChangesAsync();

        }

    }
}
}
