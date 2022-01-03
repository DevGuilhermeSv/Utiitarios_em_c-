
public class ReadFile{
    public static List<string> ReadFile(string folder, string filename)
        {
            List<string> lines = new List<string>();
            if (File.Exists(Path.Combine(folder, filename)))
            {
                StreamReader reader = new StreamReader(Path.Combine(folder, filename));
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());

                }
                reader.Close();
            }
            return lines;
        }
}