using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Extensions.Session;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Models;

namespace Pitchball.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
            HttpContext.Session.SetObject("55", new
            {
                Login = "Wolfy",
                Role = "User",
            });

            return View();
		}

		[HttpGet]
		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		[HttpGet]
		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		[HttpGet]
		public IActionResult Privacy()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Regulations()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Login()
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
