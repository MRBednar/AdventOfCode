using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCodeRunner
{
    public class Day1 : IDay
    {
        public struct CoOrds
        {
            public int x, y;

            public CoOrds(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
        public void Run()
        {
            List<CoOrds> stops = new List<CoOrds>();
            CoOrds stop = new CoOrds();
            int dir = 1;
            stop.x = 0;
            stop.y = 0;
            CoOrds EasterHQ = new CoOrds();
            bool ebFound = false;
            String[] moves = null;


            stops.Add(stop);
            using (StreamReader sr = new StreamReader("Day1Input.txt"))
            {
                // Since lines don't matter in this day, just get all of
                // the directions at once. The break them into individual
                // turn/move commands
                IEnumerable<string> inputs = File.ReadLines("Day1Input.txt");
                foreach(string input in inputs)
                {
                    string[] inputSplit = { ", " };
                    moves = input.Split(inputSplit, StringSplitOptions.RemoveEmptyEntries);
                }
            }

            Regex letterRgx = new Regex(@"\d");
            Regex numberRgx = new Regex(@"\D");
            foreach (var move in moves)
            {
                string direction = letterRgx.Replace(move, String.Empty);
                string stringDistance = numberRgx.Replace(move, String.Empty);
                int distance = int.Parse(stringDistance);
                dir = rotate(dir, direction);

                var restults = walk(distance, stops, stop, EasterHQ, dir, ebFound);
                stop = restults.Item1;
                EasterHQ = restults.Item2;
                ebFound = restults.Item3;


            }
            Console.WriteLine("Full Path distance away from start: {0}", Math.Abs(stop.x) + Math.Abs(stop.y));
            Console.WriteLine("Easter Bunny HQ distance: {0}", Math.Abs(EasterHQ.x) + Math.Abs(EasterHQ.y));
        }

        public static Tuple<CoOrds, CoOrds, bool> walk(int distance,List<CoOrds> stops ,CoOrds stop, CoOrds EasterHQ, int dir, bool ebFound)
        {
            // Determines which direction to increment
            // Checks to see if we've been here before 
            int steps = 0;
            while (steps < distance)
            {
                if (dir == 1) {
                    stop.y++;
                } else if (dir == 2)
                {
                    stop.x++;
                } else if (dir == 3)
                {
                    stop.y--;
                } else
                {
                    stop.x--;
                }
                        
                if (ebFound == false)
                {
                    if (stops.Contains(stop))
                    {
                        ebFound = true;
                        EasterHQ = stop;
                    } else
                    {
                        stops.Add(stop);
                    }
                }
                steps++;
            }
            var returnTuple = Tuple.Create(stop, EasterHQ, ebFound);
            return returnTuple;
        }

        public static int rotate(int dir, string turn)
        {
            // simple function to figure out the direction you'll be facing after the turn
            // 1 = Up, 2 = Right, 3 = Down, 4 = Left
            if (turn.Contains("R"))
            {
                dir++;
                if (dir > 4)
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
    }
}
