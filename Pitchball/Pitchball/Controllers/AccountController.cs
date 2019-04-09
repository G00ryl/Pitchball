using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Extensions.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Infrastructure.Commands.Account;
using Pitchball.Infrastructure.Commands.Captain;
using Pitchball.Infrastructure.Services.Interfaces;

namespace Pitchball.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly ICaptainService _captainService;

        public AccountController(IUserService userService, IAccountService accountService, ICaptainService captainService)
        {
            _userService = userService;
            _accountService = accountService;
            _captainService = captainService;
        }

        #region Registration
        [HttpGet("register/type/player")]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpGet("register/type/captain")]
        public IActionResult RegisterCaptainWithTeam()
        {
            return View();
        }

        [HttpPost("register/type/player")]
        public async Task<IActionResult> RegisterUserAsync(CreateAccount command)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterUser", command);
            }

            try
            {
                await _userService.AddAsync(command);

                ViewBag.ShowSuccess = true;
                ViewBag.SuccessMessage = "Rejestracja zakończona pomyślnie";
                ModelState.Clear();

                return View("RegisterUser");
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";

                return View("RegisterUser");
            }
        }

        [HttpPost("register/type/captain")]
        public async Task<IActionResult> RegisterCaptainWithTeamAsync(CreateCaptainWithTeam command)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterCaptainWithTeam", command);
            }

            try
            {
                await _captainService.AddWIthTeamAsync(command);

                ViewBag.ShowSuccess = true;
                ViewBag.SuccessMessage = "Rejestracja zakończona pomyślnie";
                ModelState.Clear();

                return View("RegisterCaptainWithTeam");
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";

                return View("RegisterCaptainWithTeam");
            }
        }
        #endregion

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginAccount command)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", command);
            }

            try
            {
                var account = await _accountService.LoginAsync(command);

                HttpContext.Session.SetString("Login", account.Login);
                HttpContext.Session.SetString("Email", account.Email);
                HttpContext.Session.SetString("Role", account.Role);

                ViewBag.ShowSuccess = true;
                ViewBag.SuccessMessage = "Zalogowano pomyślnie";

                return View("Login");
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";

                return View("Login");
            }
        }
		[HttpGet("UserPanel")]
		public IActionResult UserPanel()
		{
			return View();
		}
	}
}