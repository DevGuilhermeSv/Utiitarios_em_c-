

public class WriteJson{
     public static bool WriteJson<T>(T objectJson, string folder, string filename)
        {
            try
            {
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                var jsonString = JsonSerializer.Serialize(objectJson);
                StreamWriter writer = new StreamWriter(Path.Combine(folder, filename));
                writer.Write(jsonString);
                writer.Close();
                return true;
            }
            catch (IOException)
            {
                return false;
            }

        }
}