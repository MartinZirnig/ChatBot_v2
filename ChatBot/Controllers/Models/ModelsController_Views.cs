using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers.Models
{
    public partial class ModelsController
    {
        public IActionResult ManageModels()
        {
            return View();
        }
        public IActionResult TrainModels()
        {
            return View();
        }
    }
}
