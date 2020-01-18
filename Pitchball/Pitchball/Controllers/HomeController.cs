using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Infrastructure.Services.Interfaces;
using Pitchball.Infrastructure.ViewModels.Messages;
using Pitchball.Models;

namespace Pitchball.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;
        public HomeController(IMessageService messageService)
        {
            _messageService = messageService;
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
        
       
        [HttpGet]
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
