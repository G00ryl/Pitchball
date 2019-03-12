using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Data.QueryExtenions
{
    public static class AccountExtensions
    {
        public static async Task<bool> ExistsInDatabaseAsync(this IQueryable<Account> value, string login, string email)
            => await value.Where(x => x.Login == login || x.Email == email).AnyAsync();

        public static async Task<bool> ExistsInDatabaseAsync(this IQueryable<Account> value, int id)
            => await value.Where(x => x.Id == id).AnyAsync();

        public static IQueryable<Account> GetByLogin(this IQueryable<Account> value, string login)
            => value.Where(x => x.Login == login);

        public static IQueryable<Account> GetByEmail(this IQueryable<Account> value, string email)
            => value.Where(x => x.Email == email);

        public static IQueryable<Account> GetById(this IQueryable<Account> value, int id)
            => value.Where(x => x.Id == id);
    }
}
