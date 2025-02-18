using ChatBot.Controllers.Home;
using ChatBot.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers.Models
{
    public partial class ModelsController : Controller
    {
        private readonly ILogger<ModelsController> _logger;
        private readonly ModelsService _modelsService;

        public ModelsController(ILogger<ModelsController> logger)
        {
            _logger = logger;
            _modelsService = new ModelsService(logger);
        }
    }
}
