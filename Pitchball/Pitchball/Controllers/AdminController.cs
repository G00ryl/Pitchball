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
        private readonly IReservationService _reservationService;
        public AdminController(IContactMessageService contactMessageService, IReservationService reservationService)
        {
            _contactMessageSerivce = contactMessageService;
            _reservationService = reservationService;
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
        [CustomAuthorize("Admin")]
        [HttpGet("delete-contactMessage/{id}")]
        public async Task<IActionResult> DeleteContactMessage(int id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowMessage = true;
                ViewBag.Message = "Something went wrong";
                return RedirectToAction("ContactMessages");
            }

            try
            {
                await _contactMessageSerivce.DeleteContactMessageAsync(id);
                ViewBag.Added = true;
                return RedirectToAction("ContactMessages", "Admin");
            }
            catch (Exception)
            {
                return RedirectToAction("ContactMessages", "Admin");
            }
        }
        [CustomAuthorize("Admin")]
        [HttpGet("delete-reservation/{id}")]
        public async Task<IActionResult> DeleteReservationbyAdmin(int id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowMessage = true;
                ViewBag.Message = "Something went wrong";
                return RedirectToAction("Reservations","Reservation");
            }

            try
            {
                await _reservationService.DeleteAsync(id);
                ViewBag.Added = true;
                return RedirectToAction("Reservations", "Reservation");
            }
            catch (Exception)
            {
                return RedirectToAction("Reservations", "Reservation");
            }
        }
    }
}
