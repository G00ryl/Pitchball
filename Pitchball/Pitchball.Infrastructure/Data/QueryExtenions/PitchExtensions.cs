using Pitchball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitchball.Infrastructure.Data.QueryExtenions
{
    public static class PitchExtensions
    {
        public static IQueryable<Pitch> GetById(this IQueryable<Pitch> value, int id)
            => value.Where(x => x.Id == id);
    }
}
