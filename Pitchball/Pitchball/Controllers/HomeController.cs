using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Infrastructure.Commands.Message;
using Pitchball.Infrastructure.Services.Interfaces;
using Pitchball.Infrastructure.ViewModels.Messages;
using Pitchball.Models;
using SimpleBlog.Commands.Validation.Message;

namespace Pitchball.Controllers
{
    public class HomeController : Controller
    {
        private IMessageService _messageService;
        private IContactMessageService _contactMessageService;
        public HomeController(IMessageService messageService, IContactMessageService contactMessageService)
        {
            _messageService = messageService;
            _contactMessageService = contactMessageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet("chat")]
        public async Task<IActionResult> Chat()
        {
            var messages = await _messageService.GetMessagesAsync();
            var viewModel = new MessagesViewModel(messages);

            return View(viewModel);
        }
        [HttpPost("contact")]
        public async Task<IActionResult> Contact(CreateContactMessageCommand command)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowMessage = true;
                ViewBag.Message = "Something went wrong";
                return View();
            }

            try
            {
                CreateContactMessageValidator.CommandValidation(command);

                await _contactMessageService.AddContactMessageAsync(command);
                ViewBag.Added = true;
                return View();
            }
            catch (InternalSystemException ex)
            {
                ViewBag.ShowMessage = true;
                ViewBag.Message = ex.Message;
                return View();
            }
            catch (Exception)
            {
                ViewBag.ShowMessage = true;
                ViewBag.Message = "Something went wrong!";
                return View();
            }
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

    }
}
