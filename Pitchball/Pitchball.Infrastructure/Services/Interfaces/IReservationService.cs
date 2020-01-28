using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Reservation;
using Pitchball.Infrastructure.ViewModels.Pitch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services.Interfaces
{
    public interface IReservationService
    {
        Task AddAsync(CreateReservation command, Captain captain, Pitch pitch);
        Task<Reservation> GetAsync(int id);
        Task<IEnumerable<Reservation>> GetForPitchAsync(int pitchId);
        Task<IEnumerable<Reservation>> GetForCaptainAsync(int captainId);
        Task DeleteAsync(int id);
        Task<IEnumerable<Reservation>> GetAllReservations();
    }
}
