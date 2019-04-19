using Microsoft.AspNetCore.Http;
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
    public class AccountImageService : IImageService
    {
        private readonly PitchContext _context;
        private readonly IAccountService _accountService;

        public AccountImageService(PitchContext context, IAccountService accountService)
        {
            _context = context;
        }

        public async Task AddAsync(int parentId, IFormFile image)
        {
            var account = await _accountService.GetAsync(parentId);

            var buffer = new byte[image.Length];
            image.OpenReadStream().Read(buffer, 0, (int)image.Length);

            var img = new AccountImage(buffer, image.ContentType);

            account.AccountImage = img;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int parentId, IFormFile image)
        {
            var img = (AccountImage)await GetAsync(parentId);

            var buffer = new byte[image.Length];
            image.OpenReadStream().Read(buffer, 0, (int)image.Length);

            img.Update(buffer, image.ContentType);

            _context.AccountImages.Update(img);

        }

        public async Task<Image> GetAsync(int parentId)
        {
            var image = await _context.AccountImages.SingleOrDefaultAsync(x => x.Account.Id == parentId);

            if (image == null)
                throw new CorruptedOperationException("Image doesn't exist.");

            return image;
        }
    }
}
