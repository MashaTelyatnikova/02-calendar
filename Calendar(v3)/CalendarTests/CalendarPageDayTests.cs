using System;
using Calendar_v3_.CalendarPageUtil;
using NUnit.Framework;

namespace CalendarTests
{
    [TestFixture]
    public class CalendarPageDayTest
    {
        [Test]
        public void Equals_ForEqualDays_ReturnsTrue()
        {
            var firstDay = new CalendarPageDay(1, DayOfWeek.Monday, false);
            var secondDay = new CalendarPageDay(1, DayOfWeek.Monday, false);

            Assert.AreEqual(firstDay, secondDay);
        }

        [Test]
        public void Equals_ForDaysWithDifferentIsSelectedProperty_ReturnsFalse()
        {
            var firstDay = new CalendarPageDay(1, DayOfWeek.Monday, false);
            var secondDay = new CalendarPageDay(1, DayOfWeek.Monday, true);

            Assert.AreNotEqual(firstDay, secondDay);
        }

        [Test]
        public void Equals_ForDaysWithDifferentDaysOfWeek_ReturnsFalse()
        {
            var firstDay = new CalendarPageDay(1, DayOfWeek.Monday, false);
            var secondDay = new CalendarPageDay(1, DayOfWeek.Friday, false);

            Assert.AreNotEqual(firstDay, secondDay);
        }

        [Test]
        public void Equals_ForDaysWithDifferentNumbers_ReturnsFalse()
        {
            var firstDay = new CalendarPageDay(1, DayOfWeek.Monday, false);
            var secondDay = new CalendarPageDay(2, DayOfWeek.Monday, false);

            Assert.AreNotEqual(firstDay, secondDay);
        }

        [Test]
        public void Equals_ForDaysWithDifferentNumbersAndDaysOfWeek_ReturnsFalse()
        {
            var firstDay = new CalendarPageDay(1, DayOfWeek.Monday, false);
            var secondDay = new CalendarPageDay(2, DayOfWeek.Friday, false);

            Assert.AreNotEqual(firstDay, secondDay);
        }
    }
}
