using AutoMapper;
using DTO;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BasicSitesServise : IBasicSitesServise
    {

        IBasicSitesReposetory _IBasicSitesReposetory;
        IMapper _IMapper;
        public BasicSitesServise(IMapper _Imapper, IBasicSitesReposetory _IBasicSitesReposetory)
        {
            this._IMapper = _Imapper;
            this._IBasicSitesReposetory = _IBasicSitesReposetory;
        }


        async public Task<BasicSiteDTO> GetByIDbasicSiteServise(int id)
        {
            BasicSite basicSiteFromReposetory = await _IBasicSitesReposetory.GetByIDBasicSiteReposetory(id);
            return _IMapper.Map<BasicSiteDTO>(basicSiteFromReposetory);

        }

        async public Task UpdateBasicSiteServise(int id, UpdateBasicSiteDTO basicSiteToUpdate)
        {
            BasicSite basicSiteToReposetory = _IMapper.Map<BasicSite>(basicSiteToUpdate);
            await _IBasicSitesReposetory.UpdateBasicSiteReposetory(id, basicSiteToReposetory);

        }


        async public Task<BasicSiteDTO> AddBasicSiteServise(AddBasicSiteDTO BasicSiteToUpdate)
        {
            BasicSite basicSiteToReposetory = _IMapper.Map<BasicSite>(BasicSiteToUpdate);

            BasicSite basicSiteFromReposetory = await _IBasicSitesReposetory.AddBasicSiteReposetory(basicSiteToReposetory);

            return _IMapper.Map<BasicSiteDTO>(basicSiteFromReposetory);
        }
    }
}
