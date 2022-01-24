namespace Utilitarios_em_DotNet
{
    public class WriteFile
    {
        public static bool WriteFile(List<string> msgs, string folder, string filename)
        {
            try
            {
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                StreamWriter writer = new StreamWriter(Path.Combine(folder, filename));
                foreach (string s in msgs)
                {
                    writer.WriteLine(s);
                }
                writer.Close();
                return true;
            }
            catch (IOException)
            {
                return false;
            }

        }

    }
}