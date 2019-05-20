using Pitchball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitchball.Infrastructure.Data.QueryExtenions
{
    public static class UserExtensions
    {
        public static IQueryable<User> GetById(this IQueryable<User> value, int id)
            => value.Where(x => x.Id == id);
    }
}
