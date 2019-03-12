using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Extensions.Session;
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
        private readonly IUserService _userService;
        private readonly ICaptainService _captainService;

        public HomeController(IUserService userService, ICaptainService captainService)
        {
            _userService = userService;
            _captainService = captainService;
        }

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

        [HttpGet]
		public IActionResult Register()
		{
			return View();
		}

        #region User Registration
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(CreateAccount command)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _userService.AddAsync(command);

                ViewBag.ShowSuccess = true;
                ViewBag.SuccessMessage = "Rejestracja zakończona pomyślnie";

                return View();
            }
            catch (CorruptedOperationException ex)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = ex.Message;

                return View();
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";

                return View();
            }
        }
        #endregion

        #region Captain Registration
        [HttpGet]
        public IActionResult RegisterCaptainWithTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCaptainWithTeamAsync(CreateCaptainWithTeam command)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _captainService.AddWIthTeamAsync(command);

                ViewBag.ShowSuccess = true;
                ViewBag.SuccessMessage = "Rejestracja zakończona pomyślnie";

                return View();
            }
            catch (CorruptedOperationException ex)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = ex.Message;

                return View();
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";

                return View();
            }
        }
        #endregion

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
