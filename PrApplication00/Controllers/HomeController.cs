using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrApplication00.DAL;
using PrApplication00.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PrApplication00.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var context = new DataContext();
            ViewBag.List = context.Users.Where(u => u.Name != "sys" && !string.IsNullOrEmpty(u.About)).OrderBy(u => u.Name).ToList();
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

        public IActionResult CreateUser()
        {
            return View();
        }

        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateUser");
            }

            var context = new DataContext();
            context.Users.Add(user);
            context.SaveChanges();
            //return View("Index");
            return Redirect("~/Home/Index");
        }
    }
}
