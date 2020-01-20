using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private IAccountService _accountService;
        public HomeController(IMessageService messageService, IContactMessageService contactMessageService, IAccountService accountService)
        {
            _messageService = messageService;
            _contactMessageService = contactMessageService;
            _accountService = accountService;
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
        [HttpPost("new-message")]
        public async Task<IActionResult> Chat(MessagesViewModel command)
        {
            if (string.IsNullOrWhiteSpace(command.NewMessage.Content))
            {
                TempData["CommentFlag"] = true;
                TempData["CommentMessage"] = "Comment can't be empty!";
                return RedirectToAction("Chat","Home");
            }

            try
            {
                var userId = int.Parse(HttpContext.Session.GetString("Id"));
                var id = await _accountService.GetAsync(userId);
                

                await _messageService.CreateMessageAsync(command.NewMessage);

                return RedirectToAction("Index", "Home");
            }
            
            catch (Exception)
            {
                ViewBag.ShowMessage = true;
                ViewBag.Message = "Something went wrong!";
                return View();
            }
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
