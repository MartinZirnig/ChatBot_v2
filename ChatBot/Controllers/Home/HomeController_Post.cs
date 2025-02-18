using System.Diagnostics;
using ChatBot.Models;
using Microsoft.AspNetCore.Mvc;
using ModelsMl;

namespace ChatBot.Controllers.Home
{
    public partial class HomeController
    {
        [HttpPost]
        public async Task<IActionResult> ChatbotApi([FromBody] ChatbotPrompt prompt)
        {
            var response = _homeService.GetAiResponse(prompt.Content);


            return Ok(response);
        }

    }
}
