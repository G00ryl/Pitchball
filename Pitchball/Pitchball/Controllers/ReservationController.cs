using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pitchball.Controllers
{
    [Route("reservations")]
    public class ReservationController : Controller
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync()
        {
            throw new NotImplementedException();
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