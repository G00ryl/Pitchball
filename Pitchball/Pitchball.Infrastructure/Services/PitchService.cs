using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Pitch;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Data.QueryExtenions;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task AddPitchAsync(CreatePitchCommand command)
        {
            var pitch = new Pitch(command.Name, command.Surface, command.Lightning, command.Street, command.City);
            await _context.Pitches.AddAsync(pitch);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var pitch = await _context.Pitches.SingleOrDefaultAsync(x => x.Id == id);
            _context.Pitches.Remove(pitch);

            await _context.SaveChangesAsync();
        }
        public async Task<Pitch> GetAsync(int id)
        {
            var pitch = await _context.Pitches.GetById(id).Include(x => x.Reservations).Include(x => x.PitchImage).SingleOrDefaultAsync();

            if (pitch == null)
                throw new CorruptedOperationException("Pitch doesn't exist");

            return pitch;
        }

        public async Task<IEnumerable<Pitch>> GetAllAsync()
            => await Task.FromResult(_context.Pitches.OrderBy(x => x.Id));
    }

}
