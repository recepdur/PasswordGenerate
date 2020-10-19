using System;
using System.Collections.Generic;  
using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerate
{
    internal class Program
    {
        private static void Main(string[] args)
        { 
            byte counter = 0;
            while (counter++ < 10)
                Console.WriteLine(GeneratePassword1(20));

            Console.WriteLine("");
            Console.WriteLine("");

            counter = 0;
            while (counter++ < 10)
                Console.WriteLine(GeneratePassword2(30)); 
        }

        public static string GeneratePassword1(int length = 4, string charSet = null)
        {
            if (string.IsNullOrEmpty(charSet))
                charSet = "ACDEFGHJKLMNPQRSTUVWXYZabcdefhkmnoprstwxyz2345679@$-!"; // BIOgijlqvu018

            var strBuilder = new StringBuilder();
            using (var provider = new RNGCryptoServiceProvider())
            {
                while (strBuilder.Length < length)
                {
                    byte[] oneByte = new byte[1];
                    provider.GetNonZeroBytes(oneByte);
                    char character = (char)oneByte[0];
                    //Console.WriteLine(charSet.IndexOf(character));
                    if (charSet.IndexOf(character) != -1)
                    {
                        strBuilder.Append(character);
                    }
                }
            }
            return strBuilder.ToString();
        }

        public static string GeneratePassword2(int length = 4, string charSet = null)
        {
            if (string.IsNullOrEmpty(charSet))
                charSet = "ACDEFGHJKLMNPQRSTUVWXYZabcdefhkmnoprstwxyz2345679@$-!"; // BIOgijlqvu018

            var provider = new RNGCryptoServiceProvider();
            char[] charArray = charSet.ToCharArray();
            byte[] byteArray = new byte[length];
            provider.GetNonZeroBytes(byteArray);

            var strBuilder = new StringBuilder(length);
            for (int i = 0; i < byteArray.Length; i++)
            {
                strBuilder.Append(charArray[(int)byteArray[i] % (charArray.Length - 1)]);
            }
            return strBuilder.ToString();
        }
    }
}
