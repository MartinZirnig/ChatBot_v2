using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers.Models
{
    public partial class ModelsController
    {
        [HttpPatch]
        public IActionResult Train()
        {
            var result = _modelsService.Train();

            return Ok(result);
        }
        [HttpPatch]
        public IActionResult ReTrain()
        {
            var result = _modelsService.ReTrain();

            return Ok(result);
        }

    }
}
