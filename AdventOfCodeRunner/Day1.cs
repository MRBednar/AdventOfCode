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
            String[] moves = null;
            string inputSplit = @",\s";
            string dirsplit = @"\d";
            string distSplit = @"\D";
            Regex letterRgx = new Regex(dirsplit);
            Regex numberRgx = new Regex(distSplit);
            int dir = 1;
            int x = 0;
            int y = 0;
            List<string> stops = new List<string>();
            string start = x + ", " + y;
            stops.Add(start);
            string EBHQ = "No";
            int ebhqdist = 0;

            using (StreamReader sr = new StreamReader("Day1Input.txt"))
            {
                // Since lines don't matter in this day, just get all of
                // the directions at once. The break them into individual
                // turn/move commands
                string input = sr.ReadToEnd();
                moves = Regex.Split(input, inputSplit);

            }
            foreach (var move in moves)
            {
                int steps = 0;
                string check = "No";
                string direction = letterRgx.Replace(move, String.Empty);
                string stringDistance = numberRgx.Replace(move, String.Empty);
                int distance = int.Parse(stringDistance);
                dir = rotate(dir, direction);
                // Figure out what direction to increment up/down,  
                // Check each step against all the cords as you go if EBHQ hasn't been found
                if (dir == 1 || dir == 2)
                {
                    if (dir == 1)
                    {
                        while (steps < distance)
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
                            steps++;
                        }
                    }
                    else
                    {
                        while (steps < distance)
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
                            steps++;
                        }
                    }
                }
                else
                {
                    if (dir == 3)
                    {
                        while (steps < distance)
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
                            steps++;
                        }
                    }
                    else
                    {
                        while (steps < distance)
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
                            steps++;
                        }
                    }
                }
            }
            // Reusing start here, as it's there
            start = x + ", " + y;
            int dist = DistTranslate(start);
            ebhqdist = DistTranslate(EBHQ);
            Console.WriteLine("Full Path distance away from start: {0}", dist);
            Console.WriteLine("Easter Bunny HQ distance: {0}", ebhqdist);
        }

        public static int DistTranslate(string cords)
        {
            // Rather than track distances, this lets me turn coordinates
            // directly into distance. The values need to be ABS becase there is no REAL
            // negative distance from start
            int dist = 0;
            string[] separatingChars = { ", " };
            string[] cordList = cords.Split(separatingChars, StringSplitOptions.None);
            int x = int.Parse(cordList[0]);
            int y = int.Parse(cordList[1]);
            dist = Math.Abs(x) + Math.Abs(y);

            return dist;
        }

        public static int rotate(int dir, string turn)
        {
            // simple function to figure out the direction you'll be facing after the turn
            // 1 = Right, 2 = Up, 3 = Left, 4 = Down
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
            // Simple function for tracking if we've been on a spot before. 
            // So long as EBHQ isn't already set, sets it to a string of the
            // X/Y coordinates.
            string stop = x + ", " + y;
            
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
