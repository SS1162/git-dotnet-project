
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
    public class PlatformsReposetory : IPlatformsReposetory
    {
        MyShop330683525Context _DBContext;
        public PlatformsReposetory(MyShop330683525Context _DBContext)
        {
            this._DBContext = _DBContext;
        }

        async public Task<Platform?> GetByIDPlatformsReposetory(int id)
        {
            return await _DBContext.Platforms.FirstOrDefaultAsync(x => x.PlatformId == id);
        }

        async public Task<IEnumerable<Platform>> GetPlatformsReposetory()
        {
            return await _DBContext.Platforms.ToListAsync();
        }

        async public Task<Platform> AddPlatformReposetory(Platform platform)
        {
            await _DBContext.Platforms.AddAsync(platform);
            await _DBContext.SaveChangesAsync();
            return platform;
        }

        async public Task UpdatePlatformReposetory(int id, Platform platform)
        {
            _DBContext.Platforms.Update(platform);
            await _DBContext.SaveChangesAsync();
        }

        async public Task<bool> DeletePlatformReposetory(int id)
        {
            var platformObjectToDelete = await _DBContext.Platforms.FirstOrDefaultAsync(x => x.PlatformId == id);

            var BasicSite = await _DBContext.BasicSites.FirstOrDefaultAsync(x => x.BasicSitesPlatforms == id);
            if (BasicSite != null)
            {
                return false;
            }


            var cartItem = await _DBContext.CartItems.FirstOrDefaultAsync(x => x.BasicSitesPlatforms == id);
            if (cartItem != null)
            {
                return false;
            }


            var oredersItem = await _DBContext.OrdersItems.FirstOrDefaultAsync(x => x.BasicSitesPlatforms == id);
            if (oredersItem != null)
            {
                return false;
            }
            if (platformObjectToDelete == null)
            {
                return false;
            }
            _DBContext.Platforms.Remove(platformObjectToDelete);
            await _DBContext.SaveChangesAsync();
            return true;
        }
    }
}
