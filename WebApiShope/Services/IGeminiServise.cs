using DTO;

namespace Services
{
    public interface IGeminiServise
    {
        Task<Resulte<string>> getGeminiForUserProductServise(int id, string userRequest);
    }
}