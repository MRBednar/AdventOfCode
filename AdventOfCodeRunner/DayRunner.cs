using System;
using System.Collections.Generic;

namespace AdventOfCodeRunner
{
    class DayRunner
    {
        public static void Main(string[] args)
        {
            // I wanted a simple way to run whatever day's
            // code in whatever order I wanted. This takes
            // the days as inputs and runs them one by one
            int day;
            foreach(string arg in args)
            {
                if (int.TryParse(arg, out day))
                {
                    foo[day].Run();
                }
                Console.ReadKey();
            }
        }

        public static Dictionary<int, IDay>
            foo = new Dictionary<int, IDay>
            {
                {1, new Day1() },
                {2, new Day2() },
                {3, new Day3() },
                {4, new Day4() },
                {5, new Day5() },
            };
    }
}
