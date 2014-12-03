using System;
using NUnit.Framework;
using Calendar_v3_.CultureUtils;

namespace CalendarTests
{
    [TestFixture]
    public class CultureTests
    {
        [TestCase(DayOfWeek.Monday, DayOfWeek.Sunday)]
        [TestCase(DayOfWeek.Tuesday, DayOfWeek.Monday)]
        [TestCase(DayOfWeek.Wednesday, DayOfWeek.Tuesday)]
        [TestCase(DayOfWeek.Thursday, DayOfWeek.Wednesday)]
        [TestCase(DayOfWeek.Friday, DayOfWeek.Thursday)]
        [TestCase(DayOfWeek.Saturday, DayOfWeek.Friday)]
        [TestCase(DayOfWeek.Sunday, DayOfWeek.Saturday)]
        public void GetLastDayOfWeek_ForSpecificFirstDay_ReturnsCorrectDay(DayOfWeek firstDayOfWeek, DayOfWeek expectedLastDayOfWeek)
        {
            Assert.That(Culture.GetLastDayOfWeek(firstDayOfWeek), Is.EqualTo(expectedLastDayOfWeek));
        }

        [TestCase(DayOfWeek.Monday, DayOfWeek.Monday, 0)]
        [TestCase(DayOfWeek.Tuesday, DayOfWeek.Monday, 1)]
        [TestCase(DayOfWeek.Wednesday, DayOfWeek.Monday, 2)]
        [TestCase(DayOfWeek.Thursday, DayOfWeek.Monday, 3)]
        [TestCase(DayOfWeek.Friday, DayOfWeek.Monday, 4)]
        [TestCase(DayOfWeek.Saturday, DayOfWeek.Monday, 5)]
        [TestCase(DayOfWeek.Sunday, DayOfWeek.Monday, 6)]
        [TestCase(DayOfWeek.Monday, DayOfWeek.Tuesday, 6)]
        [TestCase(DayOfWeek.Tuesday, DayOfWeek.Tuesday, 0)]
        [TestCase(DayOfWeek.Wednesday, DayOfWeek.Tuesday, 1)]
        [TestCase(DayOfWeek.Thursday, DayOfWeek.Tuesday, 2)]
        [TestCase(DayOfWeek.Friday, DayOfWeek.Tuesday, 3)]
        [TestCase(DayOfWeek.Saturday, DayOfWeek.Tuesday, 4)]
        [TestCase(DayOfWeek.Sunday, DayOfWeek.Tuesday, 5)]
        [TestCase(DayOfWeek.Monday, DayOfWeek.Wednesday, 5)]
        [TestCase(DayOfWeek.Tuesday, DayOfWeek.Wednesday, 6)]
        [TestCase(DayOfWeek.Wednesday, DayOfWeek.Wednesday, 0)]
        [TestCase(DayOfWeek.Thursday, DayOfWeek.Wednesday, 1)]
        [TestCase(DayOfWeek.Friday, DayOfWeek.Wednesday, 2)]
        [TestCase(DayOfWeek.Saturday, DayOfWeek.Wednesday, 3)]
        [TestCase(DayOfWeek.Sunday, DayOfWeek.Wednesday, 4)]
        [TestCase(DayOfWeek.Monday, DayOfWeek.Thursday, 4)]
        [TestCase(DayOfWeek.Tuesday, DayOfWeek.Thursday, 5)]
        [TestCase(DayOfWeek.Wednesday, DayOfWeek.Thursday, 6)]
        [TestCase(DayOfWeek.Thursday, DayOfWeek.Thursday, 0)]
        [TestCase(DayOfWeek.Friday, DayOfWeek.Thursday, 1)]
        [TestCase(DayOfWeek.Saturday, DayOfWeek.Thursday, 2)]
        [TestCase(DayOfWeek.Sunday, DayOfWeek.Thursday, 3)]
        [TestCase(DayOfWeek.Monday, DayOfWeek.Friday, 3)]
        [TestCase(DayOfWeek.Tuesday, DayOfWeek.Friday, 4)]
        [TestCase(DayOfWeek.Wednesday, DayOfWeek.Friday, 5)]
        [TestCase(DayOfWeek.Thursday, DayOfWeek.Friday, 6)]
        [TestCase(DayOfWeek.Friday, DayOfWeek.Friday, 0)]
        [TestCase(DayOfWeek.Saturday, DayOfWeek.Friday, 1)]
        [TestCase(DayOfWeek.Sunday, DayOfWeek.Friday, 2)]
        [TestCase(DayOfWeek.Monday, DayOfWeek.Saturday, 2)]
        [TestCase(DayOfWeek.Tuesday, DayOfWeek.Saturday, 3)]
        [TestCase(DayOfWeek.Wednesday, DayOfWeek.Saturday, 4)]
        [TestCase(DayOfWeek.Thursday, DayOfWeek.Saturday, 5)]
        [TestCase(DayOfWeek.Friday, DayOfWeek.Saturday, 6)]
        [TestCase(DayOfWeek.Saturday, DayOfWeek.Saturday, 0)]
        [TestCase(DayOfWeek.Sunday, DayOfWeek.Saturday, 1)]
        [TestCase(DayOfWeek.Monday, DayOfWeek.Sunday, 1)]
        [TestCase(DayOfWeek.Tuesday, DayOfWeek.Sunday, 2)]
        [TestCase(DayOfWeek.Wednesday, DayOfWeek.Sunday, 3)]
        [TestCase(DayOfWeek.Thursday, DayOfWeek.Sunday, 4)]
        [TestCase(DayOfWeek.Friday, DayOfWeek.Sunday, 5)]
        [TestCase(DayOfWeek.Saturday, DayOfWeek.Sunday, 6)]
        [TestCase(DayOfWeek.Sunday, DayOfWeek.Sunday, 0)]
        public void GetOffsetDayOfWeek_RelativeToSpecificFirstDay_ReturnsCorrectOffset
            (DayOfWeek dayOfWeek, DayOfWeek firstDayOfWeek, int expectedOffset)
        {
            Assert.That(Culture.GetOffsetDayOfWeek(dayOfWeek, firstDayOfWeek), Is.EqualTo(expectedOffset));
        }
    }
}
