using ChatBot.Controllers.Home;
using ChatBot.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers.Training
{
    public partial class TrainingController : Controller
    {
        private readonly ILogger<TrainingController> _logger;
        private readonly TrainingService _trainingService;

        public TrainingController(ILogger<TrainingController> logger)
        {
            _logger = logger;
            _trainingService = new TrainingService(logger);
        }
    }
}
