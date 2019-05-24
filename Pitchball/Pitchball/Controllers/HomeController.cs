using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Extensions.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Infrastructure.Commands.Account;
using Pitchball.Infrastructure.Commands.Captain;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Services.Interfaces;
using Pitchball.Models;

namespace Pitchball.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
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

        [HttpGet("register/type")]
        public IActionResult ChooseRegisterType()
        {
            return View();
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

        [Route("{*url}", Order = 999)]
        public IActionResult CatchAll()
        {
            Response.StatusCode = 404;
            return View("PageNotFound");
        }
    }
}
