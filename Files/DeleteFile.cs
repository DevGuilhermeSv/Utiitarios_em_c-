namespace Utilitarios_em_DotNet
{
public class DeleteFile{
 public static void DeleteFile(string pathFile)
        {
            if (File.Exists(pathFile))
                File.Delete(pathFile);
        }

    
}
}      