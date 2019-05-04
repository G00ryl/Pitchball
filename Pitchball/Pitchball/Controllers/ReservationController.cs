using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Infrastructure.Commands.Reservation;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Services.Interfaces;

namespace Pitchball.Controllers
{
    [Route("reservations")]
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateReservation command)
        {
            // Validation
            var captainId = int.Parse(HttpContext.Session.GetString("Id"));

            try
            {
                var pitch = await _pitchService.GetAsync(command.PitchId);
                var captain = await _captainService.GetAsync(captainId);

                await _reservationService.AddAsync(command, captain, pitch);

                // return something
            }
            catch (CorruptedOperationException ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("pitch/{id}")]
        public async Task<IActionResult> GetForPitchAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("captain/{id}")]
        public async Task<IActionResult> GetForCaptainAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}