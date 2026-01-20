
namespace Services
{
    public interface Igemini
    {
        Task<string> RunGeminiForUserProduct(string userRequest, string category);
    }
}