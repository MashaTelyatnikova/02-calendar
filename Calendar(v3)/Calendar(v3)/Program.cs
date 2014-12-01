using System;
using System.Globalization;
using Calendar_v3_.CalendarPagePainterUtils;
using Calendar_v3_.CalendarPageUtils;

namespace Calendar_v3_
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine(@"Еnter two arguments - the current date and output filename.");
                return;
            }

            var date = args[0];
            var outputFileName = args[1];
            var culture = DateTimeFormatInfo.CurrentInfo ?? DateTimeFormatInfo.InvariantInfo;

            DateTime currentDate;
            if (!DateTime.TryParse(date, culture, DateTimeStyles.AssumeLocal, out currentDate))
            {
                Console.WriteLine("Invalid format date. The correct formats are : \n{0}", 
                    string.Join("\n", culture.GetAllDateTimePatterns()));

                return;
            }

            using (var calendarPageImage = CalendarPagePainter.Paint(new CalendarPage(currentDate)))
            {
                calendarPageImage.Save(outputFileName);
            }
        }
    }
}
