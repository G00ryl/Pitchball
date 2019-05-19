using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Data.QueryExtenions
{
    public static class ReservationExtensions
    {
        public static async Task<bool> ExistsInDatabaseAsync(this IQueryable<Reservation> value, int id)
            => await value.Where(x => x.Id == id).AnyAsync();

        public static IQueryable<Reservation> GetById(this IQueryable<Reservation> value, int id)
            => value.Where(x => x.Id == id);
    }
}
