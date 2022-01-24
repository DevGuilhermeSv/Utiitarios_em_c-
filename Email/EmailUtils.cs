using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using System.IO;
using Utilitarios_em_DotNet.StringUtils;
namespace Utilitarios_em_DotNet.EmailsUtils
{
    public class EmailUtils
    {
        public static bool emailValidator(string email)
        {
            var empty = new Regex(@"[a-zA-Z0-9_*&#]+\@[a-zA-Z0-9_*&#]+(\.[a-zA-Z0-9_*&#])+");
            if (empty.IsMatch(email))
            { return true; }
            return false;
        }


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

            if (pass.Length < 8)
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


        public static string CreateRecoverCode(string emailcode, IWebHostEnvironment environment)
        {
            var path = Path.Combine(environment.ContentRootPath, "Codes");

            string code = StringUtils.StringUtils.CreateRandomString(5);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //StreamWriter writer = new StreamWriter(controller.Server.MapPath("~/Codes/") + emailcode);
            StreamWriter writer = new StreamWriter(path + emailcode);
            writer.WriteLine(code);
            writer.Close();
            return code;
        }

        public static string GetRecoverCode(string emailcode, IWebHostEnvironment environment)
        {
            string code = null;
            var path = Path.Combine(environment.ContentRootPath, "Codes");

            if (File.Exists(path + emailcode))
            {
                StreamReader reader = new StreamReader(path + emailcode);
                code = reader.ReadLine();
                reader.Close();
            }
            return code;
        }

        public static void DeleteRecoverCode(string emailcode, IWebHostEnvironment environment)
        {
            var path = Path.Combine(environment.ContentRootPath, "Codes");

            if (File.Exists(path + emailcode))
                File.Delete(path + emailcode);
        }


    }
}