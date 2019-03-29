using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Extensions.Session;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Infrastructure.Commands.Account;
using Pitchball.Infrastructure.Commands.Captain;
using Pitchball.Infrastructure.Extensions.Exceptions;
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

        [HttpPost("register/type/captain")]
        public async Task<IActionResult> RegisterCaptainWithTeam(CreateCaptainWithTeam command)
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
                ModelState.Clear();

                return View();
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";

                return View();
            }
        }

        [HttpPost("register/type/player")]
        public async Task<IActionResult> RegisterUser(CreateAccount command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            try
            {
                await _userService.AddAsync(command);

                ViewBag.ShowSuccess = true;
                ViewBag.SuccessMessage = "Rejestracja zakończona pomyślnie";
                ModelState.Clear();

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

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginAccount command)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var account = await _accountService.LoginAsync(command);

                HttpContext.Session.SetObject("sesion", new
                {
                    Login = account.Login,
                    Email = account.Email,
                    Rolle = account.Role
                });

                ViewBag.ShowSuccess = true;
                ViewBag.SuccessMessage = "Zalogowano pomyślnie";

                return View();
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";

                return View();
            }
        }
    }
}