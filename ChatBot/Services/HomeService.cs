using ChatBot.Models;
using ModelsMl;

namespace ChatBot.Services
{
    public class HomeService
    {
        private ILogger _logger;
        public HomeService(ILogger logger)
        {
            _logger = logger;
        }

        public ChatbotResponse GetAiResponse(string input)
        {
            try
            {
                var result = Api.GetResponse(input);
                return new ChatbotResponse(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAiResponse");
                return new("error");
            }
        }


    }
}
