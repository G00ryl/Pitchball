using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Pitchball.Domain.Models;
using Pitchball.Infrastructure.Commands.Reservation;
using Pitchball.Infrastructure.Data;
using Pitchball.Infrastructure.Data.QueryExtenions;
using Pitchball.Infrastructure.Extensions.Exceptions;
using Pitchball.Infrastructure.Services.Interfaces;
using Pitchball.Infrastructure.ViewModels.Pitch;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var reservation = new Reservation(command.Name, command.StartDate, command.EndDate);

            if (_context.Reservations.Where(x => x.Pitch.Id == pitch.Id).Any(y => reservation.IsOverlaping(y)) == true)
                throw new CorruptedOperationException("Rezerwacja na tym boisku w podanym okresie już istnieje! Sprawdź wszystkie rezerwacje w widoku boiska.");

            if (captain.Reservations.Where(x => x.StartDate.Date == command.StartDate.Date).Count() >= 2)
                throw new CorruptedOperationException("Maksymalna ilość rezerwacji na dzień to: 2.");

            reservation.Pitch = pitch;
            reservation.Captain = captain;

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = await GetAsync(id);

            _context.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation> GetAsync(int id)
        {
            if (await _context.Reservations.ExistsInDatabaseAsync(id) == false)
                throw new CorruptedOperationException("Reservation with this id doesn't exist.");

            return await _context.Reservations.Include(x => x.Captain).Include( x => x.Pitch).GetById(id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Reservation>> GetForCaptainAsync(int captainId)
        {
            return await Task.FromResult(_context.Reservations.Where(x => x.Captain.Id == captainId).AsEnumerable());
        }

        public async Task<IEnumerable<Reservation>> GetForPitchAsync(int pitchId)
        {
            return await Task.FromResult(_context.Reservations.Where(x => x.Pitch.Id == pitchId).AsEnumerable());
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
            => await Task.FromResult(_context.Reservations.Include(x => x.Pitch).OrderBy(x => x.StartDate));
    }
}