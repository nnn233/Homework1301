using System;

namespace DateTimeLibrary
{
    public class DateTimeClass
    {
        private static int FindDifference(DateTime dateStart, DateTime dateEnd)
        {
            return (dateEnd.Date - dateStart.Date).Days;

        }

        private static bool IsLeapYear(DateTime date)
        {
            var year = date.Year;
            if (year % 4 == 0)
                if (year % 400 == 0)
                    return true;
                else if (year % 100 != 0)
                    return true;
                else return false;
            else return false;
        }

        private static DayTimes FindDayTimes(DateTime time)
        {
            var hour = time.Hour;
            if (hour >= 6 && hour <= 10)
                return DayTimes.Morning;
            if (hour > 10 && hour <= 17)
                return DayTimes.Noon;
            if (hour > 17 && hour < 22)
                return DayTimes.Evening;
            return DayTimes.Night;
        }

        private static string FormatDateTime(DateTime date)
        {
            return date.ToString("HH:mm dd.MM.yyyy");
        }
    }
}
