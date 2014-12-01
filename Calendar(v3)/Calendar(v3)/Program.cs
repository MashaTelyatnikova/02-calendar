using System;
using System.Text.RegularExpressions;

namespace Calendar_v3_
{
    public class Program
    {
        private readonly string date;
        private readonly string outputFileName;

        static void Main(string[] args)
        {
            try
            {
                var program = new Program(args[0], args[1]);
                program.Run();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(@"Еnter two arguments - the current date and output filename.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Program(string date, string outputFileName)
        {
            this.date = date;
            this.outputFileName = outputFileName;
        }

        public void Run()
        {
            if (!IsValidFormatDate(date))
                throw new Exception(@"Invalid format date. The correct format is dd/mm/yyyy");

            DateTime currentDate;

            if (!DateTime.TryParse(date, out currentDate))
                throw new Exception(@"Incorrect date.");

            using (var calendarPageImage = CalendarPagePainter.CalendarPagePainter.Paint(new CalendarPageUtil.CalendarPage(currentDate)))
            {
                calendarPageImage.Save(outputFileName);
            }
        }

        public static bool IsValidFormatDate(string date)
        {
            var validFormatRegex = new Regex(@"\d{2}/\d{2}/\d{3}");

            return validFormatRegex.IsMatch(date) && date.Length == 10;
        }
    }
}
