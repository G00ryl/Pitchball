using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface IPitchImage
    {
        Task<Image> GetPictureAsync(int parentId);
        Task<Image> DeleteImageAsync(int imageId);
    }
}
