using ChatBot.Controllers.Home;
using ChatBot.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers
{
    public partial class DatabaseController : Controller
    {
        private readonly ILogger<DatabaseController> _logger;
        private readonly DatabaseService _databaseService;

        public DatabaseController(ILogger<DatabaseController> logger)
        {
            _logger = logger;
            _databaseService = new DatabaseService(logger);
        }
    }
}
