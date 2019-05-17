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
        [Theory]
        [IsOverlapingData]
        public void IsOverlaping_Should_Return_True(Domain.Models.Reservation inDatabaseReservation, Domain.Models.Reservation newReservation)
        {
            // Arrange
            bool? isOverlaping = null;

            // Act
            isOverlaping = newReservation.IsOverlaping(inDatabaseReservation);

            // Assert
            Assert.True(isOverlaping);
        }

        [Theory]
        [IsNotOverlapingData]
        public void IsOverlaping_Should_Return_False(Domain.Models.Reservation inDatabaseReservation, Domain.Models.Reservation newReservation)
        {
            // Arrange
            bool? isOverlaping = null;

            // Act
            isOverlaping = newReservation.IsOverlaping(inDatabaseReservation);

            // Assert
            Assert.False(isOverlaping);
        }
    }
}
