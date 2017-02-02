using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCodeRunner
{
    public class Day3 : IDay
    {
        public void Run()
        {
            int validTriangles = 0;
            int side1;
            int side2;
            int side3;

            using (StreamReader sr = new StreamReader("Day3Input.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string input = sr.ReadLine();
                    string[] inputSplit = {" "};
                    string[] args = input.Split(inputSplit, StringSplitOptions.RemoveEmptyEntries);
                    side1 = int.Parse(args[0]);
                    side2 = int.Parse(args[1]);
                    side3 = int.Parse(args[2]);
                    if (side1+side2 > side3 && side2 + side3 > side1 && side3 + side1 > side2)
                    {
                        validTriangles++;
                    }
                }

            }
            Console.WriteLine("Number of valid Triangles: {0}", validTriangles);
        }
    }
}
