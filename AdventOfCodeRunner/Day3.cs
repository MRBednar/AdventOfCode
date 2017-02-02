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
            int part1Triangles = 0;
            int part2Triangles = 0;
            int side1;
            int side2;
            int side3;
            int[] triangle1 = new int[3];
            int[] triangle2 = new int[3];
            int[] triangle3 = new int[3];
            int row = 0;

            using (StreamReader sr = new StreamReader("Day3Input.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string input = sr.ReadLine();
                    string[] inputSplit = {" "};
                    string[] args = input.Split(inputSplit, StringSplitOptions.RemoveEmptyEntries);
                    side1 = int.Parse(args[0]);
                    triangle1[row] = side1;
                    side2 = int.Parse(args[1]);
                    triangle2[row] = side2;
                    side3 = int.Parse(args[2]);
                    triangle3[row] = side3;
                    if (side1+side2 > side3 && side2 + side3 > side1 && side3 + side1 > side2)
                    {
                        part1Triangles++;
                    }
                    row++;
                    if (row % 3 == 0)
                    {
                        if (triangle1[0] + triangle1[1] > triangle1[2] && triangle1[1] + triangle1[2] > triangle1[0] && triangle1[2] + triangle1[0] > triangle1[1])
                        {
                            part2Triangles++;
                        }
                        if (triangle2[0] + triangle2[1] > triangle2[2] && triangle2[1] + triangle2[2] > triangle2[0] && triangle2[2] + triangle2[0] > triangle2[1])
                        {
                            part2Triangles++;
                        }
                        if (triangle3[0] + triangle3[1] > triangle3[2] && triangle3[1] + triangle3[2] > triangle3[0] && triangle3[2] + triangle3[0] > triangle3[1])
                        {
                            part2Triangles++;
                        }
                        row = 0;
                    }
                }

            }
            Console.WriteLine("Number of valid Triangles From Part 1: {0}", part1Triangles);
            Console.WriteLine("Number of valid Triangles From Part 2: {0}", part2Triangles);
        }
    }
}
