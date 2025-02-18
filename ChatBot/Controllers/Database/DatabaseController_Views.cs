using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers
{
    public partial class DatabaseController
    {
        public IActionResult TrainData()
        {
            return View();
        }
        public IActionResult ManageDatabase()
        {
            return View();
        }
    }
}
