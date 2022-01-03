using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


    public static class HashEncryptor
    {

        //we are using SHA1 because fits on password datamodel on database, 
        //but we can use anyone. For this, we need to change the database model
        private static HashAlgorithm _algorithm = SHA1.Create();

        public static string Encrypt(string value)
        {
            var encodedValue = Encoding.UTF8.GetBytes(value);
            var encryptedPassword = _algorithm.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }

            return sb.ToString();
        }

        //Verifica Encriptação
        public static bool VerifyEncryption(string valueTypted, string valueRegistered)
        {
            if (string.IsNullOrEmpty(valueRegistered))
                throw new NullReferenceException("Argument can't be null");
            return Encrypt(valueTypted) == valueRegistered;
        }


    }
