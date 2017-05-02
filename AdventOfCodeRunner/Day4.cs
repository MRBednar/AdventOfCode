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
                    char[] distinctletters = letterAndCheck[0].Distinct().ToArray();
                    int checkInt = 100000000;
                    char checkChar = 'A';
                    bool isGood = true;
                    Console.WriteLine("Checking Line: {0}", input);
                    foreach (char letter in letterAndCheck[1])
                    {
                        int count = letterAndCheck[0].Count(f => f == letter);
                        Console.WriteLine("Letter: {0}   | Count: {1}", letter, count);
                        if (count > checkInt)
                        {
                            //Console.WriteLine("Invalid letter: {0}", letter);
                            isGood = false;
                            break;
                        }
                        else if (count == checkInt)
                        {
                            int index = char.ToUpper(letter) - 64;
                            int checkIndex = char.ToUpper(checkChar) - 64;
                            if (index < checkIndex)
                            {
                                //Console.WriteLine("Invalid letter: {0}", letter);
                                isGood = false;
                                break;
                            }
                        }
                        checkInt = count;
                        checkChar = letter;
                    }

                    if (isGood)
                    {
                        sectorIDSum1 = sectorIDSum1 + int.Parse(numbers);
                        Console.WriteLine("Valid line, Current SectorID Sum: {0}", sectorIDSum1);
                    }

                    Console.ReadKey();
                }
                Console.WriteLine("Sum of Sector IDs: {0}", sectorIDSum1);
            }
        }
    }
}
