using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment _environment;
        private readonly IPitchImage _pitchImage;

        public PitchController(IPitchService pitchservice, IHostingEnvironment enviroment, IPitchImage pitchImage)
        {
            _pitchservice = pitchservice;
            _environment = enviroment;
            _pitchImage = pitchImage;
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

        [HttpGet("{id}/image")]
        public async Task<IActionResult> GetPictureAsync(int id)
        {
            if (!ModelState.IsValid)
                return null;

            try
            {
                var image = await _pitchImage.GetPictureAsync(id);

                return File(image.ImageContent, image.ImageType);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}