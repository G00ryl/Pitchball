using Pitchball.Domain.Models;
using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface IPitchImage
    {
        Task<PitchImage> GetPictureAsync(int parentId);

        Task DeleteAsync(int id);

        Task DeleteAsync(PitchImage image);
    }
}