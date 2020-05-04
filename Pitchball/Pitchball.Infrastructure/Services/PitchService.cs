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
        private readonly IPitchImage _imageService;

        public PitchService(PitchContext context, IPitchImage imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task AddPitchAsync(CreatePitchCommand command)
        {
            var pitch = new Pitch(command.Name, command.Surface, command.Lightning, command.Street, command.City);
            await _context.Pitches.AddAsync(pitch);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pitch = await GetAsync(id);
            await _imageService.DeleteAsync(pitch.PitchImage);

            _context.Pitches.Remove(pitch);

            await _context.SaveChangesAsync();
        }

        public async Task<Pitch> GetAsync(int id)
        {
            return await _context.Pitches.GetById(id)
                .Include(x => x.Comments)
                .ThenInclude(y => y.Creator)
                .Include(x => x.Reservations)
                .ThenInclude(y => y.Captain)
                .Include(x => x.PitchImage).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Pitch>> GetAllAsync()
            => await Task.FromResult(_context.Pitches.Include(x => x.PitchImage).Include(x => x.Reservations).OrderBy(x => x.Id));
    }
}