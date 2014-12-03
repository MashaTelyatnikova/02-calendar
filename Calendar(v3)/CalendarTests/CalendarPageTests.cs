using System;
using System.Collections.Generic;
using Calendar_v3_.CalendarPageUtils;
using NUnit.Framework;

namespace CalendarTests
{
    [TestFixture]
    public class CalendarPageTests
    {
        [Test]
        public void CalendarPage_ForRandomYearAndMonth_ReturnsCorrectPage()
        {
            var calendarPage = new CalendarPage(new DateTime(2014, 11, 30));
            var expectedDays = new List<CalendarPageDay>()
            {
                new CalendarPageDay(1, DayOfWeek.Saturday, false),
                new CalendarPageDay(2, DayOfWeek.Sunday, false),
                new CalendarPageDay(3, DayOfWeek.Monday, false),
                new CalendarPageDay(4, DayOfWeek.Tuesday, false),
                new CalendarPageDay(5, DayOfWeek.Wednesday, false),
                new CalendarPageDay(6, DayOfWeek.Thursday, false),
                new CalendarPageDay(7, DayOfWeek.Friday, false),
                new CalendarPageDay(8, DayOfWeek.Saturday, false),
                new CalendarPageDay(9, DayOfWeek.Sunday, false),
                new CalendarPageDay(10, DayOfWeek.Monday, false),
                new CalendarPageDay(11, DayOfWeek.Tuesday, false),
                new CalendarPageDay(12, DayOfWeek.Wednesday, false),
                new CalendarPageDay(13, DayOfWeek.Thursday, false),
                new CalendarPageDay(14, DayOfWeek.Friday, false),
                new CalendarPageDay(15, DayOfWeek.Saturday, false),
                new CalendarPageDay(16, DayOfWeek.Sunday, false),
                new CalendarPageDay(17, DayOfWeek.Monday, false),
                new CalendarPageDay(18, DayOfWeek.Tuesday, false),
                new CalendarPageDay(19, DayOfWeek.Wednesday, false),
                new CalendarPageDay(20, DayOfWeek.Thursday, false),
                new CalendarPageDay(21, DayOfWeek.Friday, false),
                new CalendarPageDay(22, DayOfWeek.Saturday, false),
                new CalendarPageDay(23, DayOfWeek.Sunday, false),
                new CalendarPageDay(24, DayOfWeek.Monday, false),
                new CalendarPageDay(25, DayOfWeek.Tuesday, false),
                new CalendarPageDay(26, DayOfWeek.Wednesday, false),
                new CalendarPageDay(27, DayOfWeek.Thursday, false),
                new CalendarPageDay(28, DayOfWeek.Friday, false),
                new CalendarPageDay(29, DayOfWeek.Saturday, false),
                new CalendarPageDay(30, DayOfWeek.Sunday, true),
            };

            Assert.That(calendarPage.Year, Is.EqualTo(2014));
            Assert.That(calendarPage.Month, Is.EqualTo(11));
            Assert.That(calendarPage.Days, Is.EqualTo(expectedDays));
        }

        [Test]
        public void CalendarPage_ForLeapYearAndFebruary_ReturnsCorrectPage()
        {
            var calendarPage = new CalendarPage(new DateTime(2000, 2, 21));
            var expectedDays = new List<CalendarPageDay>()
            {
                new CalendarPageDay(1, DayOfWeek.Tuesday, false),
                new CalendarPageDay(2, DayOfWeek.Wednesday, false),
                new CalendarPageDay(3, DayOfWeek.Thursday, false),
                new CalendarPageDay(4, DayOfWeek.Friday, false),
                new CalendarPageDay(5, DayOfWeek.Saturday, false),
                new CalendarPageDay(6, DayOfWeek.Sunday, false),
                new CalendarPageDay(7, DayOfWeek.Monday, false),
                new CalendarPageDay(8, DayOfWeek.Tuesday, false),
                new CalendarPageDay(9, DayOfWeek.Wednesday, false),
                new CalendarPageDay(10, DayOfWeek.Thursday, false),
                new CalendarPageDay(11, DayOfWeek.Friday, false),
                new CalendarPageDay(12, DayOfWeek.Saturday, false),
                new CalendarPageDay(13, DayOfWeek.Sunday, false),
                new CalendarPageDay(14, DayOfWeek.Monday, false),
                new CalendarPageDay(15, DayOfWeek.Tuesday, false),
                new CalendarPageDay(16, DayOfWeek.Wednesday, false),
                new CalendarPageDay(17, DayOfWeek.Thursday, false),
                new CalendarPageDay(18, DayOfWeek.Friday, false),
                new CalendarPageDay(19, DayOfWeek.Saturday, false),
                new CalendarPageDay(20, DayOfWeek.Sunday, false),
                new CalendarPageDay(21, DayOfWeek.Monday, true),
                new CalendarPageDay(22, DayOfWeek.Tuesday, false),
                new CalendarPageDay(23, DayOfWeek.Wednesday, false),
                new CalendarPageDay(24, DayOfWeek.Thursday, false),
                new CalendarPageDay(25, DayOfWeek.Friday, false),
                new CalendarPageDay(26, DayOfWeek.Saturday, false),
                new CalendarPageDay(27, DayOfWeek.Sunday, false),
                new CalendarPageDay(28, DayOfWeek.Monday, false),
                new CalendarPageDay(29, DayOfWeek.Tuesday, false)
            };

            Assert.That(calendarPage.Year, Is.EqualTo(2000));
            Assert.That(calendarPage.Month, Is.EqualTo(2));
            Assert.That(calendarPage.Days, Is.EqualTo(expectedDays));
        }

        [Test]
        public void CalendarPage_ForNotLeapYearAndFebruary_ReturnsCorrectPage()
        {
            var calendarPage = new CalendarPage(new DateTime(2015, 2, 2));
            var expectedDays = new List<CalendarPageDay>()
            {
                new CalendarPageDay(1, DayOfWeek.Sunday, false),
                new CalendarPageDay(2, DayOfWeek.Monday, true),
                new CalendarPageDay(3, DayOfWeek.Tuesday, false),
                new CalendarPageDay(4, DayOfWeek.Wednesday, false),
                new CalendarPageDay(5, DayOfWeek.Thursday, false),
                new CalendarPageDay(6, DayOfWeek.Friday, false),
                new CalendarPageDay(7, DayOfWeek.Saturday, false),
                new CalendarPageDay(8, DayOfWeek.Sunday, false),
                new CalendarPageDay(9, DayOfWeek.Monday, false),
                new CalendarPageDay(10, DayOfWeek.Tuesday, false),
                new CalendarPageDay(11, DayOfWeek.Wednesday, false),
                new CalendarPageDay(12, DayOfWeek.Thursday, false),
                new CalendarPageDay(13, DayOfWeek.Friday, false),
                new CalendarPageDay(14, DayOfWeek.Saturday, false),
                new CalendarPageDay(15, DayOfWeek.Sunday, false),
                new CalendarPageDay(16, DayOfWeek.Monday, false),
                new CalendarPageDay(17, DayOfWeek.Tuesday, false),
                new CalendarPageDay(18, DayOfWeek.Wednesday, false),
                new CalendarPageDay(19, DayOfWeek.Thursday, false),
                new CalendarPageDay(20, DayOfWeek.Friday, false),
                new CalendarPageDay(21, DayOfWeek.Saturday, false),
                new CalendarPageDay(22, DayOfWeek.Sunday, false),
                new CalendarPageDay(23, DayOfWeek.Monday, false),
                new CalendarPageDay(24, DayOfWeek.Tuesday, false),
                new CalendarPageDay(25, DayOfWeek.Wednesday, false),
                new CalendarPageDay(26, DayOfWeek.Thursday, false),
                new CalendarPageDay(27, DayOfWeek.Friday, false),
                new CalendarPageDay(28, DayOfWeek.Saturday, false)
            };

            Assert.That(calendarPage.Year, Is.EqualTo(2015));
            Assert.That(calendarPage.Month, Is.EqualTo(2));
            Assert.That(calendarPage.Days, Is.EqualTo(expectedDays));
        }
    }
}
