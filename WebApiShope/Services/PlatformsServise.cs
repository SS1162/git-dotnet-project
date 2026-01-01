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
        IPlatformsReposetory _platformsReposetory;
        IMapper _mapper;
        IBasicSitesReposetory _basicSitesReposetory;
        ICartsReposetory _cartsReposetory;
        IOrdersReposetory _ordersReposetory;
        public PlatformsServise(IPlatformsReposetory platformsReposetory, IMapper mapper, IBasicSitesReposetory basicSitesReposetory, ICartsReposetory cartsReposetory, IOrdersReposetory ordersReposetory)
        {

            this._platformsReposetory = platformsReposetory;
            this._mapper = mapper;
            this._basicSitesReposetory = basicSitesReposetory;
            this._cartsReposetory = cartsReposetory;
            this._ordersReposetory = ordersReposetory;
        }

        async public Task<IEnumerable<PlatformsDTO>> GetPlatformsServise()
        {
            IEnumerable<Platform> platformList = await _platformsReposetory.GetPlatformsReposetory();
            return _mapper.Map<IEnumerable<PlatformsDTO>>(platformList);
        }

        async public Task<PlatformsDTO> AddPlatformServise(AddPlatformDTO platformToAdd)
        {

            Platform PlatformToReposetory = _mapper.Map<Platform>(platformToAdd);
            //add prompt with gemini
            PlatformToReposetory.PlatformsPrompt = "fdfbnfgn";
            Platform platformFromReposetory = await _platformsReposetory.AddPlatformReposetory(PlatformToReposetory);
            return _mapper.Map<PlatformsDTO>(platformFromReposetory);
        }

        async public Task<Resulte<PlatformsDTO>> UpdatePlatformServise(int id, PlatformsDTO platform)
        {
            if (id != platform.PlatformID)
            {
                Resulte<PlatformsDTO>.Failure("The id's are diffrent");
            }
            Platform? checkIfPlatformExist = await _platformsReposetory.GetByIDPlatformsReposetory(id);
            if (checkIfPlatformExist == null)
            {
                Resulte<PlatformsDTO>.Failure("The platform id isn't exist");
            }

            Platform PlatformToReposetory = _mapper.Map<Platform>(platform);
            //add prompt with gemini
            PlatformToReposetory.PlatformsPrompt = "fdfbnfgn";
            await _platformsReposetory.UpdatePlatformReposetory(id, PlatformToReposetory);

            return Resulte<PlatformsDTO>.Success(null);
        }

        async public Task<Resulte<PlatformsDTO>> DeletePlatformServise(int id)
        {

            Platform? checkIfPlatformExist = await _platformsReposetory.GetByIDPlatformsReposetory(id);
            if (checkIfPlatformExist == null)
            {
                return Resulte<PlatformsDTO>.Failure("The Platform id not exist");
            }
            BasicSite? BasicSite = await _basicSitesReposetory.CheckIfHasPlatformByPlatformID(id);
            if (BasicSite != null)
            {
                return Resulte<PlatformsDTO>.Failure("The is a basic site that refernce to the platform");
            }


            CartItem? checkIfCartItemExist = await _cartsReposetory.CheckIfHasPlatformByPlatformID(id);
            if (checkIfCartItemExist != null)
            {
                return Resulte<PlatformsDTO>.Failure("The is a cart items that refernce to the platform");
            }


            OrdersItem checkIfOrderItemExist = await _ordersReposetory.CheckIfHasPlatformByPlatformID(id);
            if (checkIfOrderItemExist != null)
            {
                return Resulte<PlatformsDTO>.Failure("The is a order items that refernce to the platform");
            }

            await _platformsReposetory.DeletePlatformReposetory(id);
            return Resulte<PlatformsDTO>.Success(null);
        }
    }
}
