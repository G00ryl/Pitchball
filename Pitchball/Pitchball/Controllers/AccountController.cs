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

        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(CreateAccount command)
        {
            if (!ModelState.IsValid)
            {
                return View("../Home/RegisterUser");
            }

            try
            {
                await _userService.AddAsync(command);

                ViewBag.ShowSuccess = true;
                ViewBag.SuccessMessage = "Rejestracja zakończona pomyślnie";

                return View("../Home/RegisterUser");
            }
            catch (CorruptedOperationException ex)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = ex.Message;

                return View("../Home/RegisterUser");
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";

                return View("../Home/RegisterUser");
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
    }
}