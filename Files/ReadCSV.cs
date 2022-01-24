namespace Utilitarios_em_DotNet
{
 public class ReadCSV{
public static List<string[]> ReadCSV(string path)
        {
            List<string[]> list = new List<string[]>();
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                reader.ReadLine();
                while (!reader.EndOfStream)  
                    list.Add(reader.ReadLine().Split(';'));     
                reader.Close();
            }
            return list;
        
        }
}
}