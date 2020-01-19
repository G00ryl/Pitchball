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
 
    public class AdminController : Controller
    {
        private readonly IContactMessageService _contactMessageSerivce;
        public AdminController(IContactMessageService contactMessageService)
        {
            _contactMessageSerivce = contactMessageService;
        }
       
        [HttpGet("AdminPanel")]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [HttpGet("ContactMessages")]
        public async Task<IActionResult> ContactMessages()
        {
            var contactMessages = await _contactMessageSerivce.GetMessagesAsync();

            return View(contactMessages);
        }
    }
}
