using System;
using System.Collections.Generic;
using Utilitarios_em_DotNet.FilesUtils;
namespace Utilitarios_em_DotNet.DateUtils
{
    public class DateUtils
    {
        public static int FindLastDayOfMonth(int month)
        {
            // ignorando anos bissextos
            int dayf = month > 7 ? (month % 2 == 0 ? 31 : 30) : (month % 2 != 0 ? 31 : month != 2 ? 30 : 28);
            return dayf;
        }
        // receives month number and returns its short name
        public static string ConvertMonthName(int month, string culture)
        {
            if (culture != "en-US")
            {
                switch (month)
                {
                    case 1:
                        return "jan";

                    case 2:
                        return "fev";

                    case 3:
                        return "mar";

                    case 4:
                        return "abr";

                    case 5:
                        return "mai";

                    case 6:
                        return "jun";

                    case 7:
                        return "jul";

                    case 8:
                        return "ago";

                    case 9:
                        return "set";

                    case 10:
                        return "out";

                    case 11:
                        return "nov";

                    case 12:
                        return "dez";

                    default:
                        return "";
                }

            }
            switch (month)
            {
                case 1:
                    return "January";

                case 2:
                    return "February";

                case 3:
                    return "March";

                case 4:
                    return "April";

                case 5:
                    return "May";

                case 6:
                    return "June";

                case 7:
                    return "July";

                case 8:
                    return "August";

                case 9:
                    return "September";

                case 10:
                    return "October";

                case 11:
                    return "November";

                case 12:
                    return "December";

                default:
                    return "";
            }
        }
        public static List<DateTime> getLastWeekPeriod()
        {
            List<DateTime> period = new List<DateTime>();
            DateTime now = DateTime.Now;

            int day = now.Day - 7;
            int month = now.Month;
            int year = now.Year;

            if (now.Day <= 7)
            {
                if (now.Month == 1)
                {
                    day = 31 - (7 - now.Day);
                    month = 12;
                    year = now.Year - 1;
                }
                else
                {

                    day = FindLastDayOfMonth(now.Month - 1) - (7 - now.Day);
                    month = now.Month - 1;
                }
            }

            period.Add(new DateTime(year, month, day, 5, 0, 0));
            period.Add(now);

            return period;
        }
        public static List<DateTime> getPeriod(int month, int year)
        {
            var day = DateTime.Now.Day;
            var lastmonth = month == 1 ? 12 : month - 1;

            if (day == FindLastDayOfMonth(month))
            {
                day = FindLastDayOfMonth(lastmonth);
            }

            return getPeriod(day, month, year, day, lastmonth, year);
        }
        /*
         * receives a month and a year and returns the DateTime List of two days: the first and last from this month/year
         */
        public static List<DateTime> getPeriod(int day, int month, int year, int dayff, int monthf, int yearf)
        {

            if (month <= 0 || month > 12 || year > DateTime.Now.Year)
            {
                return null;
            }

            // starting - setting the last day
            if (day > 28)
            {
                if (month == 2)
                {
                    day = 28;
                }
                else
                {
                    day = FindLastDayOfMonth(month);
                }
            }

            // ending - setting the last day 
            if (dayff > 28)
            {
                if (monthf == 2)
                {
                    dayff = 28;
                }
                else
                {
                    dayff = FindLastDayOfMonth(monthf);
                }
            }

            DateTime start = new DateTime(year, month, day, 5, 0, 0);
            DateTime finish = new DateTime(yearf, monthf, dayff, 23, 0, 0);

            //checking if the date was in the future (invalid)
            if (DateTime.Compare(finish, DateTime.Now) >= 0)
            {
                finish = DateTime.Now;
            }

            // if the before comes after the after...
            if (DateTime.Compare(finish, start) < 0)
            {
                var holder = start;
                start = finish;
                finish = holder;
            }

            return new List<DateTime>()
            {
                start, finish
            };
        }

    }
}
