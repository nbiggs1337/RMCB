using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RMCB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace RMCB.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        
        public HomeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet("Admin")]
        public IActionResult Admin()
        {
            //HARDCODE LOGIC SO ONLY ADMIN ACC CAN ACCESS BY ID
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
