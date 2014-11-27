using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calendar_v2_
{
    public static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine(@"Еnter two arguments - the current date and output filename.");
                return;
            }

            var date = args[0];
            var outputFileName = args[1];

            if (!IsValidFormatDate(date))
            {
                Console.WriteLine(@"Invalid format date. The correct format is dd/mm/yyyy");
                return;
            }
            
            DateTime currentDate;

            if (!DateTime.TryParse(date, out currentDate))
            {
                Console.WriteLine(@"Incorrect date.");
                return;
            }
            
            var calendarImage = CalendarPagePainter.Paint(new CalendarPage(currentDate));
            calendarImage.Save(outputFileName);
        }

        public static bool IsValidFormatDate(string date)
        {
            var validFormatRegex = new Regex(@"\d{2}/\d{2}/\d{3}");

            return validFormatRegex.IsMatch(date) && date.Length == 10;
        }
    }
}
