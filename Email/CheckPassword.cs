using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Utilitarios_em_DotNet
{
     public static class CheckPassword
    {
        

        public static string Verify(string pass, string pass_confirm)
        {
            if (pass == pass_confirm)
            {
                return Verify(pass_confirm);
            }
            else
            {
                return "Passwords do not match!";

            }
        }
        public static string Verify(string pass)
        {
            var regCapital = new Regex("[A-Z]");
            var regSmall = new Regex("[a-z]");
            var regNumber = new Regex("[0-9]");
            var regSpecial = new Regex("[^A-Za-z0-9]");
           
            if(pass.Length < 8)
            {
                return "The password must contain, at least, eight characters!";
            }

                if (regCapital.IsMatch(pass))
                {
                    if (regSmall.IsMatch(pass))
                    {
                        if (regNumber.IsMatch(pass))
                        {
                            if (regSpecial.IsMatch(pass))
                            {
                                return "";
                            }
                            else
                            {
                                return "The password must contain, at least, one special character!";
                            }
                        }
                        else
                        {
                            return "The password must contain, at least, one number!";

                        }
                    }
                    else
                    {

                        return "The password must contain, at least, one small letter!";
                    }
                }
                else
                {
                    return "The password must contain, at least, one capital letter!";
                }
           
        }
    }

}