using System;
using Calendar_v3_.CalendarPageUtils;
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

            Assert.That(firstDay.Equals(secondDay), Is.True);
        }

        [Test]
        public void Equals_ForDaysWithDifferentIsSelectedProperty_ReturnsFalse()
        {
            var firstDay = new CalendarPageDay(1, DayOfWeek.Monday, false);
            var secondDay = new CalendarPageDay(1, DayOfWeek.Monday, true);

            Assert.That(firstDay.Equals(secondDay), Is.False);
        }

        [Test]
        public void Equals_ForDaysWithDifferentDaysOfWeek_ReturnsFalse()
        {
            var firstDay = new CalendarPageDay(1, DayOfWeek.Monday, false);
            var secondDay = new CalendarPageDay(1, DayOfWeek.Friday, false);

            Assert.That(firstDay.Equals(secondDay), Is.False);
        }

        [Test]
        public void Equals_ForDaysWithDifferentNumbers_ReturnsFalse()
        {
            var firstDay = new CalendarPageDay(1, DayOfWeek.Monday, false);
            var secondDay = new CalendarPageDay(2, DayOfWeek.Monday, false);

            Assert.That(firstDay.Equals(secondDay), Is.False);
        }

        [Test]
        public void Equals_ForDaysWithDifferentNumbersAndDaysOfWeek_ReturnsFalse()
        {
            var firstDay = new CalendarPageDay(1, DayOfWeek.Monday, false);
            var secondDay = new CalendarPageDay(2, DayOfWeek.Friday, false);

            Assert.That(firstDay.Equals(secondDay), Is.False);
        }
    }
}
