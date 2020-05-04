using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models;
using Pitchball.Domain.Models.Base;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services
{
    public class PitchImageService : IPitchImage
    {
        private readonly PitchContext _context;

        public PitchImageService(PitchContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var image = await _context.PitchImages.SingleOrDefaultAsync(x => x.Id == id);

            if (image == null)
                throw new CorruptedOperationException("Image doesn't exist.");

            _context.PitchImages.Remove(image);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PitchImage image)
        {
            _context.PitchImages.Remove(image);

            await _context.SaveChangesAsync();
        }

        public async Task<PitchImage> GetPictureAsync(int parentId)
        {
            var image = await _context.PitchImages.SingleOrDefaultAsync(x => x.Pitch.Id == parentId);

            if (image == null)
                throw new CorruptedOperationException("Image doesn't exist.");

            return image;
        }
    }
}