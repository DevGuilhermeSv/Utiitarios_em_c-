using System;
using System.Collections.Generic;
using Utilitarios_em_DotNet.FilesUtils;
namespace Utilitarios_em_DotNet.DateUtils
{
    /**
    <summary>
        Fornece classes uteis para  a manipulação de Datas
    </summary>
    */
    public class DateUtils
    {
        /**
        <summary>
            Retorna o ultimo dia do Mês
        </summary>
        */
        public static int FindLastDayOfMonth(int month)
        {
            // ignorando anos bissextos
            int dayf = month > 7 ? (month % 2 == 0 ? 31 : 30) : (month % 2 != 0 ? 31 : month != 2 ? 30 : 28);
            return dayf;
        }

        /// <summary>
        ///  Devolve o mês em string de acordo com a cultura escolhida
        /// </summary>
        /// <param name="month">Mes 0-12.</param>
        /// <param name="culture">String que representa a cultura atual.</param>
        public static string ConvertMonthName(int month, string culture)
        {
            if (month > 12 || month < 1)
                return "";
            List<string> mes = new List<string>(
                "Janeiro", "Fevereiro", "Março",
                "Abril", "Maio", "Junho", "Julho",
                "Agosto", "Setembro", "Outubro",
                "Novembro", "Dezembro"
            );
            List<string> mesI = new List<string>(
                "January", "February", "March",
                "April", "May", "June", "July",
                "August", "September", "October",
                "November", "December"
            );

            if (culture != "en-US")
            {
                return mes(month);

            }
            return mesI(month);
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
        /**
        <summary>
         Recebe o mês e o ano e retorno uma Lista de DateTime de dois dias: o primeiro e o ultimo do mes/ano
        </summary>
         */
        public static List<DateTime> getPeriod(DateTime initial, DateTime final)
        {
            var month = initial.Month, monthf = final.Month;
            var day = initial.Day, dayf = final.Day;
            var year = initial.Year,yearf = final.Year;
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
            if (dayf > 28)
            {
                if (monthf == 2)
                {
                    dayf = 28;
                }
                else
                {
                    dayf = FindLastDayOfMonth(monthf);
                }
            }

            DateTime start = new DateTime(year, month, day, 5, 0, 0);
            DateTime finish = new DateTime(yearf, monthf, dayf, 23, 0, 0);

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
