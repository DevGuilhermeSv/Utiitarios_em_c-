 public class getPeriod{
      public static List<DateTime> getPeriod(int month, int year)
        {
            var day = DateTime.Now.Day;
            var lastmonth = month == 1 ? 12 : month - 1;

            if (day == Utils.FindLastDayOfMonth(month))
            {
                day = Utils.FindLastDayOfMonth(lastmonth);
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
