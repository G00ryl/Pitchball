using Pitchball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Pitchball.Tests.Arrange.DataAttributes
{
    public class IsNotOverlapingData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            // New reservation starts and ends before the old one
            yield return new object[]
            {
                // Reservation thah already exists in database
                new Reservation("Old", new DateTime(2018, 5, 5, 20, 0, 0), new DateTime(2018, 5, 5, 22, 0, 0)),

                // New reservation that user wants to add.
                new Reservation("New", new DateTime(2018, 5, 5, 5, 25, 0), new DateTime(2018, 5, 5, 6, 15, 0))
            };

            // New reservation starts and ends after the old one
            yield return new object[]
            {
                // Reservation thah already exists in database
                new Reservation("Old", new DateTime(2018, 5, 5, 10, 30, 0), new DateTime(2018, 5, 5, 11, 15, 0)),

                // New reservation that user wants to add.
                new Reservation("New", new DateTime(2018, 5, 5, 11, 30, 0), new DateTime(2018, 5, 5, 12, 45, 0))
            };
        }
    }
}
