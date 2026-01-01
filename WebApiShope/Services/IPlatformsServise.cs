using DTO;

namespace Services
{
    public interface IPlatformsServise
    {
        Task<PlatformsDTO> AddPlatformServise(AddPlatformDTO platformToAdd);
        Task<Resulte<PlatformsDTO>> DeletePlatformServise(int id);
        Task<IEnumerable<PlatformsDTO>> GetPlatformsServise();
        Task<Resulte<PlatformsDTO>> UpdatePlatformServise(int id, PlatformsDTO platform);
    }
}