using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pitchball.Controllers
{
    [Route("pitch")]
    public class PitchController : Controller
    {
        [HttpGet("list")]
        public IActionResult Pitches()
        {
            return View();
        }
    }
}