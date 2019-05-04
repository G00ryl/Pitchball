using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Reservation;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Services
{
    public class ReservationService : IReservationService
    {
        private readonly PitchContext _context;

        public ReservationService(PitchContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CreateReservation command, Captain captain, Pitch pitch)
        {
            // Reservation times validation

            var reservation = new Reservation(command.Name, command.StartDate, command.EndDate);

            reservation.Pitch = pitch;
            reservation.Captain = captain;

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetForCaptainAsync(int captainId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetForPitchAsync(int pitchId)
        {
            throw new NotImplementedException();
        }
    }
}
