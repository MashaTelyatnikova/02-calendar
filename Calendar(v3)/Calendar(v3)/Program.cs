using System;
using System.Globalization;
using Calendar_v3_.CalendarPagePainterUtils;
using Calendar_v3_.CalendarPageUtils;
using Calendar_v3_.CultureUtils;

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
            var culture = DateTimeFormatInfo.CurrentInfo;

            DateTime currentDate;
            if (!DateTime.TryParse(date, culture, DateTimeStyles.None, out currentDate))
            {
                Console.WriteLine("Invalid format date. The correct formats are : \n{0}", 
                    string.Join("\n", culture.GetAllDateTimePatterns()));

                return;
            }

            var painter = new CalendarPagePainter(new CultureHelper(CultureInfo.CurrentCulture));
            using (var calendarPageImage = painter.Paint(new CalendarPage(currentDate)))
            {
                calendarPageImage.Save(outputFileName);
            }
        }
    }
}
