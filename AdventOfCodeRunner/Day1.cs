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


            stops.Insert(0, stop);
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
            
            foreach (var move in moves)
            {
                Regex letterRgx = new Regex(@"\d");
                string direction = letterRgx.Replace(move, String.Empty);
                Regex numberRgx = new Regex(@"\D");
                string stringDistance = numberRgx.Replace(move, String.Empty);
                int distance = int.Parse(stringDistance);
                dir = rotate(dir, direction);
                // Figure out what direction to increment up/down,  
                // Check each step against all the cords as you go if EBHQ hasn't been found

                var restults = doThing(distance, stops, stop, EasterHQ, dir, ebFound);
                stop = restults.Item1;
                EasterHQ = restults.Item2;
                ebFound = restults.Item3;


            }
            Console.WriteLine("Full Path distance away from start: {0}", Math.Abs(stop.x) + Math.Abs(stop.y));
            Console.WriteLine("Easter Bunny HQ distance: {0}", Math.Abs(EasterHQ.x) + Math.Abs(EasterHQ.y));
        }

        public static Tuple<CoOrds, CoOrds, bool> doThing(int distance,List<CoOrds> stops ,CoOrds stop, CoOrds EasterHQ, int dir, bool ebFound)
        {
            int steps = 0;
            while (steps < distance)
            {
                switch (dir)
                {
                    case 1:
                        stop.x++;
                        break;
                    case 2:
                        stop.y++;
                        break;
                    case 3:
                        stop.x--;
                        break;
                    case 4:
                        stop.y--;
                        break;
                }
                if (ebFound == false)
                {
                    if (stops.Contains(stop))
                    {
                        ebFound = true;
                    } else
                    {
                        stops.Add(stop);
                    }
                    if (ebFound)
                    {
                        EasterHQ = stop;
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
    }
}
