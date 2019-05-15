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
            yield return new object[]
            {
                new Reservation("Case1", new DateTime(2018, 5, 5, 23, 30, 0), new DateTime(2018, 5, 6, 0, 10, 0)),
                new Reservation("Case1", new DateTime(2018, 5, 5, 23, 25, 0), new DateTime(2018, 5, 6, 0, 15, 0))
            };

            yield return new object[]
            {
                new Reservation("Case2", new DateTime(2018, 5, 5, 10, 30, 0), new DateTime(2018, 5, 5, 11, 15, 0)),
                new Reservation("Case2", new DateTime(2018, 5, 5, 10, 30, 0), new DateTime(2018, 5, 5, 10, 45, 0))
            };
        }
    }
}
