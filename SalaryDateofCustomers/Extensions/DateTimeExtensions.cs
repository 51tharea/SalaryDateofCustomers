using System;

namespace PaymentDateCalculator.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime SpecificDayOfMonth(this DateTime currentDate, int day)
        {
            if (day >= currentDate.Day)
            {
                return currentDate.AddDays(day - currentDate.Day);
            }

            var SpecificDate = currentDate.AddMonths(1);
            return new DateTime(SpecificDate.Year, SpecificDate.Month, day);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime currentDate) { return new DateTime(currentDate.Year, currentDate.Month, 1); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime currentDate)
        {
            return new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public static DateTime LastWorkingDayOfMonth(this DateTime currentDate)
        {
            DateTime Date = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));

            while (Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday)
            {
                Date = Date.AddDays(-1);
            }

            return Date;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public static DateTime LastWorkingDayOfWeek(this DateTime currentDate, int week) { return currentDate.FirstWorkingDayOfMonth().AddDays(6 * week); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public static DateTime DayBeforeLastWorkingDay(this DateTime currentDate)
        {
            DateTime Date;
            do
            {
                Date = currentDate.LastWorkingDayOfMonth().AddDays(-1);
            } while (Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday);

            return Date;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public static DateTime FirstWorkingDayOfMonth(this DateTime currentDate)
        {
            var      FirstDayOfMonth = currentDate.FirstDayOfMonth();
            DateTime FirstWorkingDay = new DateTime(FirstDayOfMonth.Year, FirstDayOfMonth.Month, FirstDayOfMonth.Day);

            switch (FirstDayOfMonth.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    FirstWorkingDay = FirstDayOfMonth.AddDays(1);
                    break;
                case DayOfWeek.Saturday:
                    FirstWorkingDay = FirstDayOfMonth.AddDays(2);
                    break;
            }

            if (FirstWorkingDay.Day > currentDate.Day)
            {
                return FirstWorkingDay;
            }

            var NextMonthDate = FirstWorkingDay.AddMonths(1);

            switch (NextMonthDate.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    NextMonthDate = NextMonthDate.AddDays(1);
                    break;
                case DayOfWeek.Saturday:
                    NextMonthDate = NextMonthDate.AddDays(2);
                    break;
            }

            return NextMonthDate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="dayOfWeek"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public static DateTime FirstXDay(this DateTime currentDate, int dayOfWeek, int week)
        {
            var XDayOfWeek = Enum.Parse<DayOfWeek>(dayOfWeek.ToString());

            var FirstXDay = currentDate.FirstDayOfMonth();

            while (FirstXDay.DayOfWeek != XDayOfWeek)
            {
                FirstXDay = FirstXDay.AddDays(1);
            }

            if (FirstXDay >= currentDate)
            {
                return FirstXDay;
            }

            FirstXDay = FirstXDay.AddMonths(1);
            FirstXDay = new DateTime(FirstXDay.Year, FirstXDay.Month, 1);


            while (FirstXDay.DayOfWeek != XDayOfWeek)
            {
                FirstXDay = FirstXDay.AddDays(1);
            }

            return FirstXDay;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="dayOfWeek"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public static DateTime LastXDay(this DateTime currentDate, int dayOfWeek, int week)
        {
            var XDayOfWeek = Enum.Parse<DayOfWeek>(dayOfWeek.ToString());
            var LastXDay   = currentDate.LastDayOfMonth();

            while (LastXDay.DayOfWeek != XDayOfWeek)
            {
                LastXDay = LastXDay.AddDays(-1);
            }


            return LastXDay;
        }
    }
}
