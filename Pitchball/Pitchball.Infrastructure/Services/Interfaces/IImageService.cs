using Microsoft.AspNetCore.Http;
using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface IImageService
    {
        Task AddAsync(int parentId, IFormFile image);
        Task UpdateAsync(int parentId, IFormFile image);
        Task<Image> GetAsync(int parentId);
    }
}
