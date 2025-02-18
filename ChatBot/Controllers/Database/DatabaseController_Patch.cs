using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers
{
    public partial class DatabaseController
    {
        [HttpPatch]
        public IActionResult UpdateIgnore(
            [FromQuery(Name = "param1")] int id, 
            [FromQuery(Name = "param2")] bool state)
        {
            var result = _databaseService.UpdateIgnore(id, state);

            return Ok(result);
        }
    }
}
