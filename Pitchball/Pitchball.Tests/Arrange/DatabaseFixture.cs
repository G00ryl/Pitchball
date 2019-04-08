using Microsoft.EntityFrameworkCore;
using Pitchball.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitchball.Tests.Arrange
{
    public class DatabaseFixture : IDisposable
    {
        public PitchContext Context { get; private set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<PitchContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;
            Context = new PitchContext(options);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
