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


            // Regex functions for cleaning up the inputs (Part 1)
            Regex letterRgx = new Regex(numberSplit);
            Regex numberRgx = new Regex(letterSplit);
            Regex removeBrackets = new Regex(bracktRMV);
            using (StreamReader sr = new StreamReader("Day4Input.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string input = sr.ReadLine();
                    string letters = letterRgx.Replace(input, String.Empty);
                    string[] letterAndCheck = Regex.Split(letters, cheksumSplit);
                    letterAndCheck[1] = removeBrackets.Replace(letterAndCheck[1], String.Empty);
                    int numbers = int.Parse(numberRgx.Replace(input, String.Empty));
                    var topChars = topFive(letterAndCheck[0].Replace("-", String.Empty));

                    if (letterAndCheck[1].Equals(topChars))
                    {
                        translateLine(letterAndCheck[0], numbers);
                        sectorIDSum1 = sectorIDSum1 + numbers;
                    }
                }
                Console.WriteLine("Sum of Sector IDs: {0}", sectorIDSum1);
            }
        }

        public class charCount
        {
            // Simple object for handling the letter counts
            public int count { get; set; }
            public char listChar { get; set; }
        }

        private string topFive (string codeCheck)
        {
            var charList = new List<charCount>();

            char[] distinct = codeCheck.Distinct().ToArray();

            // gets count for each character in the string
            foreach (char checkChar in distinct)
            {
                charCount charCheck = new charCount();
                int count = codeCheck.Count(f => f == checkChar);
                charCheck.count = count;
                charCheck.listChar = checkChar;


                charList.Add(charCheck);
            }

            // first order alphabetically, then order by letter count, and take only the top 5
            var query = charList.OrderBy(charCount => charCount.listChar);
            var top5 = query.OrderByDescending(charCount => charCount.count).Take(5);

            // Turn the top 5 into a string that can be compared to the checksum
            string topChar = "";
            int i = 0;
            foreach (charCount topPick in top5)
            {
                topChar += topPick.listChar;
                i++;
            }

            return topChar;

        }

        public void translateLine (string line, int number)
        {
            string translation = "";
            line = line.Replace("-", " ");
            int move = number % 26;
            foreach (char character in line)
            {
                if (!character.Equals(' '))
                {
                    char charPlus = (char)(((int)character) + move);
                    int charValue = Convert.ToInt32(charPlus);
                    if (charValue > 122)
                    {
                        charValue = (charValue - 122) + 96;
                    }
                    char nextChar = Convert.ToChar(charValue);
                    translation += nextChar;

                } else
                {
                    translation += " ";
                }
            }

            if (translation.Contains("north"))
            {
                Console.WriteLine("Translation: {0}   |   SectorID: {1}", translation, number);
            }
        }
    }
}
