using System;
using System.IO;

namespace AdventOfCodeRunner
{
    public class Day3 : IDay
    {
        public void Run()
        {
            // Two variable to keep track of both part's triangles
            int part1Triangles = 0;
            int part2Triangles = 0;
            // Length of sides for part 1 triangles
            int side1;
            int side2;
            int side3;
            // Length of sides for part 2 triangles
            int[] triangle1 = new int[3];
            int[] triangle2 = new int[3];
            int[] triangle3 = new int[3];
            // For tracking 3 rows for part 2 triangles
            int row = 0;

            using (StreamReader sr = new StreamReader("Day3Input.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    // Gets each line from the input text
                    // Splits them on spaces, store in list
                    string input = sr.ReadLine();
                    string[] inputSplit = {" "};
                    string[] sideLength = input.Split(inputSplit, StringSplitOptions.RemoveEmptyEntries);
                    // Store side measurements
                    side1 = int.Parse(sideLength[0]);
                    triangle1[row] = side1;
                    side2 = int.Parse(sideLength[1]);
                    triangle2[row] = side2;
                    side3 = int.Parse(sideLength[2]);
                    triangle3[row] = side3;
                    // increment row is finished
                    row++;

                    // Part 1 valid triangle check
                    if (side1+side2 > side3 && side2 + side3 > side1 && side3 + side1 > side2)
                    {
                        part1Triangles++;
                    }
                    // Checks to see if we are at the end of 3 lines for valid Part 2 Triangles
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
                        // Resets row count
                        row = 0;
                    }
                }

            }
            Console.WriteLine("Number of valid Triangles From Part 1: {0}", part1Triangles);
            Console.WriteLine("Number of valid Triangles From Part 2: {0}", part2Triangles);
        }
    }
}
