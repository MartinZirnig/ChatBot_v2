using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers.Models
{
    public partial class ModelsController 
    {
        [HttpGet]
        public IActionResult GetModelBackup()
        {
            var result = _modelsService.GetModelsBackup();

            return Ok(result);
        }

    }
}
