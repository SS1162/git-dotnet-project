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
    public class SiteTypesService : ISiteTypesService
    {

        ISiteTypesRepository _SiteTypesRepository;
        IMapper _Mapper;

        public SiteTypesService(ISiteTypesRepository _SiteTypesRepository, IMapper Mapper)
        {
            this._SiteTypesRepository = _SiteTypesRepository;
            this._Mapper = Mapper;
        }


        public async Task<IEnumerable<SiteTypeDTO>?> GetAllSiteTypesServise()
        {
            var siteTypes = await _SiteTypesRepository.GetAllSiteTypesReposetory();

            return _Mapper.Map<IEnumerable<SiteTypeDTO>>(siteTypes);

        }
        public async Task<SiteTypeDTO?> GetSiteTypesByIdServise(int id)
        {
            SiteType? siteType = await _SiteTypesRepository.GetSiteTypeByIdReposetory(id);
            return _Mapper.Map<SiteTypeDTO>(siteType);
        }

        public async Task UpdateSiteTypesByMngServise(int id, SiteTypeDTO dto)
        {
            SiteType siteType = _Mapper.Map<SiteType>(dto);
            await _SiteTypesRepository.UpdateSiteTypeByMngReposetory(id, siteType);

            ;
        }



    }
}
