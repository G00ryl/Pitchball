using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Attributes;

namespace Pitchball.Controllers
{
    [Route("pitches")]
    public class PitchController : Controller
    {
        [HttpGet("all")]
        public IActionResult Pitches()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Pitch(int id)
        {
            return View();
        }
    }
}