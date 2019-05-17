using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Reservation;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Services.Interfaces;

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

        [HttpPost("pitch/{id}/reservations")]
        public async Task<IActionResult> CreateAsync(int id, CreateReservation command)
        {
            // Validation
            var captainId = int.Parse(HttpContext.Session.GetString("Id"));

            try
            {
                var pitch = await _pitchService.GetAsync(id);
                var captain = await _captainService.GetAsync(captainId);

                await _reservationService.AddAsync(command, captain, pitch);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("pitch/{id}/reservations")]
        public async Task<IEnumerable<Reservation>> GetForPitchAsync(int id)
        {
            var reservations = await _reservationService.GetForPitchAsync(id);

            return reservations;
        }

        [HttpGet("captain/{id}/reservations")]
        public async Task<IEnumerable<Reservation>> GetForCaptainAsync(int id)
        {
            var reservations = await _reservationService.GetForCaptainAsync(id);

            return reservations;
        }

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
    }
}