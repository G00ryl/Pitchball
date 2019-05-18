using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Data.QueryExtenions;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services
{
    public class PitchService : IPitchService
    {
        private readonly PitchContext _context;

        public PitchService(PitchContext context)
        {
            _context = context;
        }

        public async Task<Pitch> GetAsync(int id)
        {
            var pitch = await _context.Pitches.GetById(id).Include(x => x.Reservations).SingleOrDefaultAsync();

            if (pitch == null)
                throw new CorruptedOperationException("Pitch doesn't exist");

            return pitch;
        }
    }
}
