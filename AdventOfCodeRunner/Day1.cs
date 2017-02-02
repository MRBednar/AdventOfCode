using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCodeRunner
{
    public class Day1 : IDay
    {
        public void Run()
        {
            String[] args = null;
            string inputSplit = @",\s";
            string dirsplit = @"\d";
            string distSplit = @"\D";
            int dir = 1;
            int dist = 0;
            int x = 0;
            int y = 0;
            List<string> stops = new List<string>();
            string start = x + ", " + y;
            stops.Add(start);
            string EBHQ = "No";
            int ebhqdist = 0;

            using (StreamReader sr = new StreamReader("C:\\Users\\mbednar\\Desktop\\Day1Input.txt"))
            {
                string input = sr.ReadToEnd();
                args = Regex.Split(input, inputSplit);

            }
            Console.WriteLine("Numbers!");
            foreach (var move in args)
            {
                int i = 0;
                string check = "No";
                String[] splitDir = Regex.Split(move, dirsplit);
                String[] splitDist = Regex.Split(move, distSplit);
                int.TryParse(splitDist[1], out int distance);
                dir = rotate(dir, splitDir[0]);
                if (dir == 1 || dir == 2)
                {
                    dist = dist + distance;
                    if (dir == 1)
                    {
                        Console.WriteLine("North: {0}", distance);
                        while (i < distance)
                        {
                            x++;
                            if (EBHQ.Equals("No"))
                            {
                                check = stopCheck(x, y, EBHQ, stops);
                                if (!check.Equals("No"))
                                {
                                    EBHQ = check;
                                }
                            }
                            i++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("East: {0}", distance);
                        while (i < distance)
                        {
                            y++;
                            if (EBHQ.Equals("No"))
                            {
                                check = stopCheck(x, y, EBHQ, stops);
                                if (!check.Equals("No"))
                                {
                                    EBHQ = check;
                                }
                            }
                            i++;
                        }
                    }
                }
                else
                {
                    dist = dist - distance;
                    if (dir == 3)
                    {
                        Console.WriteLine("South: {0}", distance);
                        while (i < distance)
                        {
                            x--;
                            if (EBHQ.Equals("No"))
                            {
                                check = stopCheck(x, y, EBHQ, stops);
                                if (!check.Equals("No"))
                                {
                                    EBHQ = check;
                                }
                            }
                            i++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("West: {0}", distance);
                        while (i < distance)
                        {
                            y--;
                            if (EBHQ.Equals("No"))
                            {
                                check = stopCheck(x, y, EBHQ, stops);
                                if (!check.Equals("No"))
                                {
                                    EBHQ = check;
                                }
                            }
                            i++;
                        }
                    }
                }
            }
            ebhqdist = DistTranslate(EBHQ);
            Console.WriteLine("Full Path distance away from start: {0}", dist);
            Console.WriteLine("Easter Bunny HQ distance: {0}", ebhqdist);
        }

        public static int DistTranslate(string cords)
        {
            int dist = 0;
            string[] separatingChars = { ", " };
            string[] cordList = cords.Split(separatingChars, StringSplitOptions.None);
            int x = int.Parse(cordList[0]);
            int y = int.Parse(cordList[1]);
            dist = x + y;

            return dist;
        }

        public static int rotate(int dir, string turn)
        {
            if (turn.Contains("R"))
            {
                dir++;
                if (dir >= 5)
                {
                    dir = 1;
                }
            }
            else
            {
                dir--;
                if (dir < 1)
                {
                    dir = 4;
                }
            }
            return dir;
        }

        public static string stopCheck(int x, int y, string EBHQ, List<string> stops)
        {
            string stop = x + ", " + y;

            Console.WriteLine(stop);
            if (stops.Contains(stop))
            {
                if (EBHQ.Equals("No"))
                {
                    EBHQ = stop;
                }
            }
            else
            {
                stops.Add(stop);
            }
            return EBHQ;
        }
    }
}
