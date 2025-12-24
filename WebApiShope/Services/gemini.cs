using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.GenAI;
using Google.GenAI.Types;
using Microsoft.Extensions.Configuration;
namespace Services
{
    public class gemini
    {
        IConfiguration _config;
        public gemini(IConfiguration _config)
        {
            this._config = _config;
        }
        public  async Task<string> RunGemini()
        {
            string myApiKey = Convert.ToString(_config.GetSection("GEMINI_API_KEY"));
            
            // יצירת הלקוח עם הגדרת המפתח בצורה מפורשת
            var client = new Client(apiKey: myApiKey);

            try
            {
                var response = await client.Models.GenerateContentAsync(
                    model: "gemini-3-flash-preview",
                    contents: "Explain how AI works in a few words"
               

                );

               return response.Candidates[0].Content.Parts[0].Text;
            }
            catch (Exception ex)
            {
               return $"Error: {ex.Message}";
            }
        }
    }
}
