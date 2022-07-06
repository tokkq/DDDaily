using System;
using System.Diagnostics;

namespace DailyProject
{
    static class Utility
    {
        public static void WriteLine(string text)
        {
            Debug.WriteLine($"[DailyProject]{text}");
        }

        public static DateTime GetFirstDayOfWeek(this DateTime dataTime, DayOfWeek startDayOfWeek)
        {
            if (startDayOfWeek == DayOfWeek.Sunday)
            {
                return dataTime.AddDays(DayOfWeek.Sunday - dataTime.DayOfWeek);
            }
            else
            {
                var d = startDayOfWeek - dataTime.DayOfWeek;
                return dataTime.AddDays((d > 0) ? d - 7 : d);
            }
        }

        public static DateTime GetLastDayOfWeek(this DateTime dataTime, DayOfWeek startDayOfWeek)
        {
            if (startDayOfWeek == DayOfWeek.Sunday)
            {
                return dataTime.AddDays(DayOfWeek.Saturday - dataTime.DayOfWeek);
            }
            else
            {
                var d = startDayOfWeek - dataTime.DayOfWeek;
                return dataTime.AddDays((d == 1) ? 0 : 6 + d);
            }
        }
    }
}
