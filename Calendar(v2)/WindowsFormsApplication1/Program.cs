using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NUnit.Framework;

namespace WindowsFormsApplication1
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                MessageBox.Show(@"Еnter one argument - the current date.");
                return;
            }

            var date = args[0];
            if (!IsValidFormatDate(date))
            {
                MessageBox.Show(@"Invalid format date. The correct format is dd/mm/yyyy");
                return;
            }

            if (!IsCorrectDate(date))
            {
                MessageBox.Show(@"Incorrect date.");
                return;
            }

            var currentDate = DateTime.Parse(date);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalendarPageWithSelectedDayPainter(new CalendarPage(currentDate.Year, currentDate.Month), currentDate.Day));
        }

        public static bool IsValidFormatDate(string date)
        {
            var validFormatRegex = new Regex(@"\d{2}/\d{2}/\d{3}");

            return validFormatRegex.IsMatch(date) && date.Length == 10;
        }

        public static bool IsCorrectDate(string date)
        {
            DateTime tmp;
            return DateTime.TryParse(date, out tmp);
        }
    }

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

        [TestCase("26/09/1994", true)]
        [TestCase("00/00/0000", false)]
        [TestCase("38/48/1994", false)]
        [TestCase("09/13/2014", false)]
        public void IsCorrectDate_Test(string input, bool expected)
        {
            Assert.That(Program.IsCorrectDate(input), Is.EqualTo(expected));
        }
    }
}
