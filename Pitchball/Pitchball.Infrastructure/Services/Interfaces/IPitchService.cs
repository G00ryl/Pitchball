using Pitchball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface IPitchService
    {
        Task<Pitch> GetAsync(int id);
        Task<IEnumerable<Pitch>> GetAllAsync();
    }
}
