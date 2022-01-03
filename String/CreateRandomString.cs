    
    public class CreateRandomString{

     public static string CreateRandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!#$%¨&*";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
        

        