using Calendar_v3_;
using NUnit.Framework;

namespace CalendarTests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void IsValidFormateDate_ValidityDate_ReturnsTrue()
        {
            Assert.That(Program.IsValidFormatDate("26/09/1994"), Is.True);
        }

        [TestCase("")]
        [TestCase("26\\09\\1994")]
        [TestCase("26/09/1994/1999/987")]
        [TestCase("12/12/1234      ;lbkv")]
        [TestCase("lalala12/12/1212")]
        public void IsValidFormateDate_InvalidDate_ReturnsFalse(string date)
        {
            Assert.That(Program.IsValidFormatDate(date), Is.False);
        }
    }
}
