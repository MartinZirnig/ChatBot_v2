using Microsoft.AspNetCore.Mvc;
using ModelsMl;
using ModelsMl.Data;

namespace ChatBot.Controllers
{
    public partial class DatabaseController
    {
        [HttpGet]
        public IActionResult GetTrainingData(
            [FromQuery(Name = "param1")] int skip, 
            [FromQuery(Name = "param2")] int top, 
            [FromQuery(Name = "param3")] bool ignored, 
            [FromQuery(Name = "param4")] bool loaded, 
            [FromQuery(Name = "param5")] Model model)
        {
            var result = _databaseService.GetTrainData(skip, top, ignored, loaded, model);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetBackups()
        {
            var result = _databaseService.GetBackups();
            return Ok(result);
        }
    }
}
