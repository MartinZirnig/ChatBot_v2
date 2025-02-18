using ChatBot.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers.Models
{
    public partial class ModelsController 
    {
        [HttpPost]
        public IActionResult BackupModel([FromBody] ModelsName name)
        {
            var result = _modelsService.BackupModel(name);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult RestoreModel([FromBody] ModelsName name)
        {
            var result = _modelsService.RestoreModel(name);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult ClearModel()
        {
            var result = _modelsService.ClearModel();
            return Ok(result);
        }
    }
}
