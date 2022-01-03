public class FindLastDayOfMonth{
    public static int FindLastDayOfMonth(int month)
        {
            // ignorando anos bissextos
            int dayf = month > 7 ? (month % 2 == 0 ? 31 : 30) : (month % 2 != 0 ? 31 : month != 2 ? 30 : 28);
            return dayf;
        }
}
