
 public class PasswordRecovery
{
    public static string CreateRecoverCode(string emailcode, IWebHostEnvironment environment) {
            var path = Path.Combine(environment.ContentRootPath, "Codes");

            string code = CreateRandomString(5);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //StreamWriter writer = new StreamWriter(controller.Server.MapPath("~/Codes/") + emailcode);
            StreamWriter writer = new StreamWriter(path + emailcode);
            writer.WriteLine(code);
            writer.Close();
            return code;
        }

        public static string GetRecoverCode(string emailcode, IWebHostEnvironment environment) {
            string code = null;
            var path = Path.Combine(environment.ContentRootPath, "Codes");

            if (File.Exists(path + emailcode)) {
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
        