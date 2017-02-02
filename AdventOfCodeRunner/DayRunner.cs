using System;
using System.Collections.Generic;

namespace AdventOfCodeRunner
{
    class DayRunner
    {
        public static void Main(string[] args)
        {
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
            };
    }
}
