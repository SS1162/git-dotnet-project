using AutoMapper;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace  Services
{
    public class PlatformsServise : IPlatformsServise
    {
        IPlatformsReposetory _IPlatformsReposetory;
        IMapper _Imapper;
        public PlatformsServise(IPlatformsReposetory _IPlatformsReposetory, IMapper _Imapper)
        {

            this._IPlatformsReposetory = _IPlatformsReposetory;
            this._Imapper = _Imapper;
        }

        async public Task<IEnumerable<PlatformsDTO>> GetPlatformsServise()
        {

            IEnumerable<Platform> platformList = await _IPlatformsReposetory.GetPlatformsReposetory();

            return _Imapper.Map<IEnumerable<PlatformsDTO>>(platformList);
        }

        async public Task<PlatformsDTO> AddPlatformServise(AddPlatformDTO platformToAdd)
        {
            Platform PlatformToReposetory = _Imapper.Map<Platform>(platformToAdd);
            //add prompt with gemini
            PlatformToReposetory.PlatformsPrompt = "fdfbnfgn";
            Platform platformFromReposetory = await _IPlatformsReposetory.AddPlatformReposetory(PlatformToReposetory);
            return _Imapper.Map<PlatformsDTO>(platformFromReposetory);
        }

        async public Task UpdatePlatformServise(int id, PlatformsDTO platform)
        {
            Platform PlatformToReposetory = _Imapper.Map<Platform>(platform);
            //add prompt with gemini
            PlatformToReposetory.PlatformsPrompt = "fdfbnfgn";
            await _IPlatformsReposetory.UpdatePlatformReposetory(id, PlatformToReposetory);
        }

        async public Task<bool> DeletePlatformServise(int id)
        {
            return await _IPlatformsReposetory.DeletePlatformReposetory(id);
        }
    }
}
