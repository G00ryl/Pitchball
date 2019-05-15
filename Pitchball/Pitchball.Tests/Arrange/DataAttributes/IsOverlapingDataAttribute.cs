using Pitchball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Pitchball.Tests.Arrange.DataAttributes
{
    public class IsOverlapingDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            // New reservation starts before the old one end ends after old reservation
            yield return new object[]
            {
                // Reservation thah already exists in database
                new Reservation("Old", new DateTime(2018, 5, 5, 23, 30, 0), new DateTime(2018, 5, 6, 0, 10, 0)),

                // New reservation that user wants to add.
                new Reservation("New", new DateTime(2018, 5, 5, 23, 25, 0), new DateTime(2018, 5, 6, 0, 15, 0))
            };

            // New reservation starts at the same time as the old one and ends during old reservation
            yield return new object[]
            {
                // Reservation thah already exists in database
                new Reservation("Old", new DateTime(2018, 5, 5, 10, 30, 0), new DateTime(2018, 5, 5, 11, 15, 0)),

                // New reservation that user wants to add.
                new Reservation("New", new DateTime(2018, 5, 5, 10, 30, 0), new DateTime(2018, 5, 5, 10, 45, 0))
            };

            // New reservation starts during the old one and ends after old reservation
            yield return new object[]
            {
                // Reservation thah already exists in database
                new Reservation("Old", new DateTime(2018, 5, 5, 10, 30, 0), new DateTime(2018, 5, 5, 11, 30, 0)),

                // New reservation that user wants to add.
                new Reservation("New", new DateTime(2018, 5, 5, 11, 00, 0), new DateTime(2018, 5, 5, 12, 00, 0))
            };

            // New reservation starts and ends during tle old one
            yield return new object[]
            {
                // Reservation thah already exists in database
                new Reservation("Old", new DateTime(2018, 5, 5, 9, 0, 0), new DateTime(2018, 5, 5, 11, 0, 0)),

                // New reservation that user wants to add.
                new Reservation("New", new DateTime(2018, 5, 5, 9, 30, 0), new DateTime(2018, 5, 5, 10, 30, 0))
            };
        }
    }
}
