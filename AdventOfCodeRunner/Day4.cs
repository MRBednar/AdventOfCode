using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCodeRunner
{
    class Day4 : IDay
    {
        public void Run()
        {
            // For keeping track of the ID Sum total
            int sectorIDSum1 = 0;
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
                    var topChars = topFive(letterAndCheck[0]);

                    if (letterAndCheck[1].Equals(topChars))
                    {
                        sectorIDSum1 = sectorIDSum1 + int.Parse(numbers);
                        Console.WriteLine("Valid line, Current SectorID Sum: {0}", sectorIDSum1);
                    }
                }
                Console.WriteLine("Sum of Sector IDs: {0}", sectorIDSum1);
            }
        }

        public class charCount
        {
            public int count { get; set; }
            public char listChar { get; set; }
        }

        private string topFive (string codeCheck)
        {
            var charList = new List<charCount>();

            char[] distinct = codeCheck.Distinct().ToArray();

           
            foreach (char checkChar in distinct)
            {
                charCount charCheck = new charCount();
                int count = codeCheck.Count(f => f == checkChar);
                charCheck.count = count;
                charCheck.listChar = checkChar;


                charList.Add(charCheck);
            }

            var query = charList.OrderBy(charCount => charCount.listChar);
            var top5 = query.OrderByDescending(charCount => charCount.count).Take(5);

            string topChar = "";
            int i = 0;
            foreach (charCount topPick in top5)
            {
                topChar += topPick.listChar;
                i++;
            }

            return topChar;

        }
    }
}
