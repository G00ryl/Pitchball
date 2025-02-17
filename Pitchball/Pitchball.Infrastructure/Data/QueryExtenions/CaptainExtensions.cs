﻿using Pitchball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pitchball.Infrastructure.Data.QueryExtenions
{
    public static class CaptainExtensions
    {
        public static IQueryable<Captain> GetById(this IQueryable<Captain> value, int id)
            => value.Where(x => x.Id == id);
    }
}
