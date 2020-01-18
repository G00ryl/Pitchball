using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Attributes;
using Pitchball.Infrastructure.Services.Interfaces;
using Pitchball.Infrastructure.ViewModels.Account;

namespace Pitchball.Controllers
{
    [Route("captain")]
    public class CaptainController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICaptainService _captainService;
        private readonly IImageService _imageService;
        private readonly IHostingEnvironment _environment;

        public CaptainController(IAccountService accountService, Func<string, IImageService> serviceAccessor,
            ICaptainService captainService, IHostingEnvironment environment)
        {
            _accountService = accountService;
            _captainService = captainService;
            _imageService = serviceAccessor("account");
            _environment = environment;
        }
        [CustomAuthorize("Captain")]
        [HttpGet("me")]
        public async Task<IActionResult> Profile()
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";
                return RedirectToAction("Index", "Home");
            }

            try
            {
                var id = int.Parse(HttpContext.Session.GetString("Id"));
                var captain = await _captainService.GetAsync(id);
                return View("CaptainPanel",captain);
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";
                return RedirectToAction("Index", "Home");
            }
        }

        [CustomAuthorize("Captain")]
        [HttpGet("me/edit")]
        public IActionResult EditProfile()
        {
            // TODO Implement rest of this method!!!
            return View("CaptainPanelEdit");
        }

        [HttpGet("{id}")]
        public IActionResult CaptainProfile(int id)
        {
            //TODO Implement this method to be able to see others profiles.
            throw new NotImplementedException();
        }

        [CustomAuthorize("Captain")]
        [HttpPost("me/edit/password")]
        public async Task<IActionResult> UpdatePasswordAsync(AccountSettingsViewModel viewModel)
        {
            var id = int.Parse(HttpContext.Session.GetString("Id"));

            if (!ModelState.IsValid)
            {
                viewModel.Account = await _accountService.GetAsync(id);

                return View("CaptainPanelEdit", viewModel);
            }

            try
            {
                await _accountService.ChangePasswordAsync(id, viewModel.Command);
                return RedirectToAction("Profile");
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";

                return RedirectToAction("EditProfile");
            }
        }

        [CustomAuthorize("Captain")]
        [HttpGet("me/avatar")]
        public async Task<IActionResult> GetPictureAsync()
        {
            var id = int.Parse(HttpContext.Session.GetString("Id"));

            if (!ModelState.IsValid)
                return null;

            try
            {
                var image = await _imageService.GetAsync(id);

                return File(image.ImageContent, image.ImageType);
            }
            catch (Exception)
            {
                var filePath = _environment.WebRootPath + "\\images\\Avatar.png";
                var imageFileStream = System.IO.File.OpenRead(filePath);
                return File(imageFileStream, "image/png");
            }
        }

        [CustomAuthorize("Captain")]
        [HttpPost("me/avatar/addOrUpdate")]
        public async Task<IActionResult> AddOrUpdatePictureAsync(AccountSettingsViewModel viewModel, IFormFile image = null)
        {
            var id = int.Parse(HttpContext.Session.GetString("Id"));

            if (!ModelState.IsValid || image == null)
            {
                viewModel.Account = await _accountService.GetAsync(id);

                return View("UserPanelEdit", viewModel);
            }

            try
            {
                if (await _imageService.ExistsForParentAsync(id) == false)
                {
                    await _imageService.AddAsync(id, image);
                }
                else
                {
                    await _imageService.UpdateAsync(id, image);
                }

                return RedirectToAction("Profile");
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Coś poszło nie tak.";

                return RedirectToAction("EditProfile");
            }
        }
    }
}