namespace Utilitarios_em_DotNet
{
public class emailValidator{
public static bool emailValidator(string email)
        {
            var empty = new Regex(@"[a-zA-Z0-9_*&#]+\@[a-zA-Z0-9_*&#]+(\.[a-zA-Z0-9_*&#])+");
            if (empty.IsMatch(email))
            { return true; }
            return false;
        }
}
}