using Microsoft.EntityFrameworkCore;
using Pitchball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitchball.Infrastructure.Data.QueryExtenions
{
    public static class AccountImageExtensions
    {
        public static async Task<bool> ExistsInDatabaseAsync(this IQueryable<AccountImage> value, int parentId)
            => await value.Where(x => x.AccountId == parentId).AnyAsync();
    }
}