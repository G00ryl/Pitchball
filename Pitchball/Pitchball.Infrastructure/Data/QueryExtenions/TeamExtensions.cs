using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Data.QueryExtenions
{
    public static class TeamExtensions
    {
        public static async Task<bool> ExistsInDatabaseAsync(this IQueryable<Team> value, string name)
           => await value.Where(x => x.Name == name).AnyAsync();

        public static async Task<bool> ExistsInDatabaseAsync(this IQueryable<Team> value, int id)
            => await value.Where(x => x.Id == id).AnyAsync();

        public static IQueryable<Team> GetByEmail(this IQueryable<Team> value, string name)
            => value.Where(x => x.Name == name);

        public static IQueryable<Team> GetById(this IQueryable<Team> value, int id)
            => value.Where(x => x.Id == id);
    }
}
