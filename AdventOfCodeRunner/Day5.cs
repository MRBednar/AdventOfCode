using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AdventOfCodeRunner
{
    public class Day5 : IDay
    {
        public void Run()
        {
            string password = "";
            char?[] passwordArray = new char?[8];
            int i = 0;
            int arraycount = 0;
            while (arraycount < 8)
            {
                string hash = CalculateMD5Hash("ugkcyxxp" + i);
                if (hash.StartsWith("00000"))
                {
                    if (password.Length < 8)
                    {
                        password += hash[5];
                    }
                    // Setting the parsedHash to 9 keeps it from being null and makes it longer than the array length
                    // So it doesn't get added if it doesn't parse
                    int parsedHash = 9;
                    if (Char.IsNumber(hash[5]))
                    {
                        parsedHash = int.Parse(hash[5].ToString());
                    }
                    if (parsedHash != 9 && parsedHash < passwordArray.Length && !passwordArray[parsedHash].HasValue)
                    {
                        passwordArray[parsedHash] = hash[6];
                        arraycount++;
                    }                    
                }
                i++;
            }
            string password2 = string.Join("", passwordArray);
            Console.WriteLine(password);
            Console.WriteLine(password2);
        }

        public string CalculateMD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("x2"));

            }

            return sb.ToString();

        }
    }
}
