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
            // Read each line in the text and write to string list
            String[] moves = null;
            using (StreamReader sr = new StreamReader("Day1Input.txt"))
            {
                List<string> inputs = null;
                while (sr.Peek() >= 0)
                {
                     inputs.Add(sr.ReadLine());
                }
                foreach(string input in inputs)
                {
                    string[] inputSplit = { ", " };
                    moves = input.Split(inputSplit, StringSplitOptions.RemoveEmptyEntries);
                }
            }

            // stops stores the coordinates we pass through between start and the Easter Bunny HQ
            // currentStop is the location we are currently at
            // dir is a numerical representation for the direction we are facing
            // easterHQ is the coordinates for the Easter Bunny HQ for part 2
            // ebFound is a bool telling us if we've found the location of easterHQ as per part 2
            // the Regexs are for spitting the turns and steps from each set of moves
            List<CoOrds> stops = new List<CoOrds>();
            CoOrds currentStop = new CoOrds();
            int dir = 1;
            currentStop.x = 0;
            currentStop.y = 0;
            CoOrds easterHQ = new CoOrds();
            bool ebFound = false;
            Regex letterRgx = new Regex(@"\d");
            Regex numberRgx = new Regex(@"\D");
            foreach (var move in moves)
            {
                string direction = letterRgx.Replace(move, String.Empty);
                string stringDistance = numberRgx.Replace(move, String.Empty);
                int distance = int.Parse(stringDistance);
                dir = rotate(dir, direction);

                var restults = walk(distance, stops, currentStop, easterHQ, dir, ebFound);
                currentStop = restults.Item1;
                easterHQ = restults.Item2;
                ebFound = restults.Item3;


            }
            Console.WriteLine("Full Path distance away from start: {0}", Math.Abs(currentStop.x) + Math.Abs(currentStop.y));
            Console.WriteLine("Easter Bunny HQ distance: {0}", Math.Abs(easterHQ.x) + Math.Abs(easterHQ.y));
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
            dir = (turn.Contains("R")) ? dir++ : dir--;
            
            if (dir > 4)
            {
                dir = 1;
            } else if (dir < 1)
            {
                dir = 4;
            }
            return dir;
        }
    }
}
