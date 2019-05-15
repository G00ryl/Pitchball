using Pitchball.Tests.Arrange.DataAttributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Pitchball.Tests.Models
{
    [Collection("User Service Tests")]
    public class Reservation
    {
        [Fact]
        [IsOverlapingData]
        public void IsOverlaping_Should_Return_True()
        {
            // Arrange
        }

    }
}
