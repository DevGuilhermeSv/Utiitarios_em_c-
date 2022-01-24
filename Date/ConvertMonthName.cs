 
   
namespace Utilitarios_em_DotNet
{
   public class ConvertMonthName{
        // receives month number and returns its short name
        public static string ConvertMonthName(int month,string culture)
        {
            if(culture != "en-US")
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
   }
}
       