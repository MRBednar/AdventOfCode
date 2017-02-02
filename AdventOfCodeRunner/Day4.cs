using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCodeRunner
{
    class Day4 : IDay
    {
        public void Run()
        {
            // For keeping track of the ID Sum total
            int sectorIDSum = 0;
            string numberSplit = @"\d";
            string letterSplit = @"\D";
            string cheksumSplit = @"\[";
            string bracktRMV = @"\]";
            // remove the hyphens because they don't mean anything (Part 1)
            string nohyphen;
            // Regex functions for cleaning up the inputs (Part 1)
            Regex letterRgx = new Regex(numberSplit);
            Regex numberRgx = new Regex(letterSplit);
            Regex removeBrackets = new Regex(bracktRMV);
            using (StreamReader sr = new StreamReader("Day4Input.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string input = sr.ReadLine();
                    nohyphen = input.Replace("-", String.Empty);
                    string letters = letterRgx.Replace(nohyphen, String.Empty);
                    string[] letterAndCheck = Regex.Split(letters, cheksumSplit);
                    letterAndCheck[1] = removeBrackets.Replace(letterAndCheck[1], String.Empty);
                    string numbers = numberRgx.Replace(nohyphen, String.Empty);
                    int test = letters.Length;
                }
            }
        }
    }
}
