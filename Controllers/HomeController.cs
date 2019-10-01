using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VitecProjekt.Models;
using System.Diagnostics;
using Microsoft.ApplicationInsights;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VitecProjekt.Controllers
{
    public class HomeController : Controller
    {
        TelemetryClient telemetry;
        public HomeController()
        {
            telemetry = new TelemetryClient();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            telemetry.TrackEvent("IndexPage");
            return View();
        }

        public IActionResult Privacy()
        {
            telemetry.TrackEvent("PrivacyPage");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Product()
        {
            telemetry.TrackEvent("ProductPage");
            return View();
        }
        public IActionResult Subscription()
        {
            telemetry.TrackEvent("SubscriptionPage");
            return View();
        }
    }
}
