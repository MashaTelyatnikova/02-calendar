using Calendar_v2_;
using NUnit.Framework;

namespace CalendarTests
{
    [TestFixture]
    public class Program_Test
    {
        [TestCase("26/09/1994", true)]
        [TestCase("", false)]
        [TestCase("26\\09\\1994", false)]
        [TestCase("26/09/1994/1999/987", false)]
        [TestCase("12/12/1234      ;lbkv", false)]
        [TestCase("lalala12/12/1212", false)]
        public void IsValidFormateDate_Test(string input, bool expected)
        {
            Assert.That(Program.IsValidFormatDate(input), Is.EqualTo(expected));
        }
    }
}
