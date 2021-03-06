﻿using System;
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
            int i = 0;
            Console.WriteLine(password.Length);
            while (password.Length < 8)
            {
                string hash = CalculateMD5Hash("ugkcyxxp" + i);
                if (hash.StartsWith("00000"))
                {
                    password += hash[5];
                }
                i++;
            }
            Console.WriteLine(password);
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
