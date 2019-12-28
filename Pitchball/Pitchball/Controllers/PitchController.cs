using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Attributes;
using Pitchball.Infrastructure.Services;
using Pitchball.Infrastructure.Services.Interfaces;

namespace Pitchball.Controllers
{
    [Route("pitches")]
    public class PitchController : Controller
    {
        private readonly IPitchService _pitchservice;

        public PitchController(IPitchService pitchservice)
        {
            _pitchservice = pitchservice;  
        }
        [HttpGet("all")]
        public async  Task<IActionResult> Pitches()
        {
            var pitches = await _pitchservice.GetAllAsync();
            return View(pitches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Pitch(string id)
        {
            try
            {
                var pitchId = int.Parse(id);
                var pitch = await _pitchservice.GetAsync(pitchId);
                var pitchViewModel = new Infrastructure.ViewModels.Pitch.PitchViewModel(pitch);

                return View(pitchViewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}