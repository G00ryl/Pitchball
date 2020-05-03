using Microsoft.EntityFrameworkCore;
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
        private readonly IPitchService _pitchService;

        public PitchImageService(PitchContext context, IPitchService pitchService)
        {
            _context = context;
            _pitchService = pitchService;
        }

        public async Task<Image> GetPictureAsync(int parentId)
        {
            var image = await _context.PitchImages.SingleOrDefaultAsync(x => x.Pitch.Id == parentId);

            if (image == null)
                throw new CorruptedOperationException("Image doesn't exist.");

            return image;
        }
        public async Task DeleteImageAsync(int imageId)
        {
            var image = await _context.PitchImages.SingleOrDefaultAsync(x => x.Pitch.Id == imageId);
            if (image == null)
            {
                _pitchService.DeleteAsync(imageId);    
            }
            else
            { 
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            _pitchService.DeleteAsync(imageId);
            }
        }
    }
}
