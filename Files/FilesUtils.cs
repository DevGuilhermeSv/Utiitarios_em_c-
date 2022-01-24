using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
namespace Utilitarios_em_DotNet.FilesUtils{
public class FilesUtils
{
    public static string GetContentType(string path)
    {
        var types = GetMimeTypes();
        var ext = Path.GetExtension(path)
            .ToLowerInvariant();
        return types[ext];
    }

    public static Dictionary<string, string> GetMimeTypes()
    {
        return new Dictionary<string, string>
    {
        {".txt", "text/plain"},
        {".pdf", "application/pdf"},
        {".doc", "application/vnd.ms-word"},
        {".docx", "application/vnd.ms-word"},
        {".xls", "application/vnd.ms-excel"},
        {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
        {".png", "image/png"},
        {".jpg", "image/jpeg"},
        {".jpeg", "image/jpeg"},
        {".gif", "image/gif"},
        {".csv", "text/csv"}
    };
    }

    public static void DeleteFile(string pathFile)
    {
        if (File.Exists(pathFile))
            File.Delete(pathFile);
    }
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

}