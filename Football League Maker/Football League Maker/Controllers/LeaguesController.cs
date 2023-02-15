using Football_League_Maker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Football_League_Maker.Controllers
{
    public class LeaguesController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

       

        public IActionResult Error()
        {
            return View();
        }
    }
}