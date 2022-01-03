 
 public class getLastWeekPeriod
{
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
                    day = Utils.FindLastDayOfMonth(now.Month - 1) - (7 - now.Day);
                    month = now.Month - 1;
                }
            }

            period.Add(new DateTime(year, month, day, 5, 0, 0));
            period.Add(now);

            return period;
        }

}
