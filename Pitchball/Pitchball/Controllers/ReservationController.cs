using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Attributes;
using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Reservation;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Services.Interfaces;
using Pitchball.Infrastructure.ViewModels.Pitch;

namespace Pitchball.Controllers
{
    [Route("reservation-management")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ICaptainService _captainService;
        private readonly IPitchService _pitchService;

        public ReservationController(IReservationService reservationService, ICaptainService captainService, IPitchService pitchService)
        {
            _reservationService = reservationService;
            _captainService = captainService;
            _pitchService = pitchService;
        }
        

        [CustomAuthorize("Captain")]
        [HttpPost("pitch/{id}/reservations")]
        public async Task<IActionResult> CreateReservation(CreateReservation command, int id )
        {
            if (! ModelState.IsValid)
            {
                ViewBag.ShowError = true;
                ViewBag.ErrorMessage = "Something went wrong";
                return View("CreateReservation", command); ;
            }

            var captainId = int.Parse(HttpContext.Session.GetString("Id"));

            try
            {
                var pitch = await _pitchService.GetAsync(id);
                var captain = await _captainService.GetAsync(captainId);

                await _reservationService.AddAsync(command, captain, pitch);
                ViewBag.ShowSuccess = true;
                ViewBag.SuccessMessage = "Dodawanie rezerwacji zakończone pomyślnie";
                return View();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [CustomAuthorize("Captain")]
        [HttpGet("pitch/{id}/reservations")]
        public IActionResult CreateReservation()
        {
            return View();
        }

        [CustomAuthorize("User, Captain, Admin")]
        [HttpGet("pitch/{id}/allreservations")]
        public async Task<IEnumerable<Reservation>> GetForPitchAsync(int id)
        {
            var reservations = await _reservationService.GetForPitchAsync(id);

            return reservations;
        }

        [CustomAuthorize("Captain")]
        [HttpGet("captain/{id}/reservations")]
        public async Task<IEnumerable<Reservation>> GetForCaptainAsync(int id)
        {
            var reservations = await _reservationService.GetForCaptainAsync(id);

            return reservations;
        }

        [CustomAuthorize("Captain")]
        [HttpPost("reservations/{id}/delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _reservationService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("reservations")]
        public async Task<IActionResult> Reservations()
        {
            try
            {
                var reservations = await _reservationService.GetAllReservations();
                return View(reservations);
            }catch(Exception)
            { 
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}