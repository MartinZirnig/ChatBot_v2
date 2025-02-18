using System.Diagnostics;
using ChatBot.Services;
using Microsoft.AspNetCore.Mvc;
using ModelsMl;

namespace ChatBot.Controllers.Home
{
    public partial class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeService _homeService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _homeService = new HomeService(logger);
        }


        private string GetIpAddress()
        {
            return
                HttpContext.Connection.RemoteIpAddress?.ToString()
                ?? "Unknown client";
        }
        private string ShortenMessage(string original, int len)
        {
            if (len < 3)
                throw new ArgumentException("Length must be at least 3 (or more)");

            if (original.Length > len)
                return $"{original[..(len - 2)]}..";
            else
                return original;
        }
    }
}
