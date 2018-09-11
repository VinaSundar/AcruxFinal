using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using MyHealth.Models;
using Microsoft.Extensions.Caching.Memory;
using MyHealth.Helpers;
using MyHealth.Integration;

namespace MyHealth.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache cache;

        public HomeController(IMemoryCache _cache)
        {
            cache = _cache;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login(LoginViewModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
                return View();

            HttpContext.Session.SetString("UserName", model.UserName);
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");

            return RedirectToAction("Dashboard");
        }


        public IActionResult LogOut()
        {
            ViewData.Remove("UserName");
            HttpContext.Session.Remove("UserName");
            return View();
        }

        public IActionResult About()
        {
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Legal()
        {
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");

            return View();
        }

        public IActionResult Identity()
        {
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["Message"] = "Your Identity page.";

            return View(new AccountIdentityViewModel());
        }

        public IActionResult Contact()
        {
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Credential()
        {
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["Message"] = "Your Credential page.";

            return View();
        }

        public IActionResult AccessOverview()
        {
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["Message"] = "Your AccessOverview page.";

            return View();
        }

        public IActionResult AccessGrantRevoke()
        {
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["Message"] = "Your AccessGrantRevoke page.";

            return View();
        }

        public IActionResult Dashboard()
        {
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            var _model = new DashboardViewModel();

            return View(_model);
        }

        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
