namespace Utilitarios_em_DotNet
{
    public class ReadJson
    {
        public static T ReadJson<T>(string folder, string filename)
        {
            T objectJson = default(T);
            if (File.Exists(Path.Combine(folder, filename)))
            {
                StreamReader jsonStringReader = new StreamReader(Path.Combine(folder, filename));
                objectJson = JsonSerializer.Deserialize<T>(jsonStringReader.ReadToEnd());
                jsonStringReader.Close();
            }
            return objectJson;
        }
    }
}