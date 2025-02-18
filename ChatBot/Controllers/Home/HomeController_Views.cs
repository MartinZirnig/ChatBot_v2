using System.Diagnostics;
using ChatBot.Models;
using Microsoft.AspNetCore.Mvc;
using ModelsMl;

namespace ChatBot.Controllers.Home
{
    public partial class HomeController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Train()
        {
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }
    }
}
