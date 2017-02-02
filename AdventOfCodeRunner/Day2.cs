using System;
using System.IO;

namespace AdventOfCodeRunner
{
    public class Day2 : IDay
    {
        public void Run()
        {
            char key1 = '5';
            char key2 = '5';

            int x1 = 2;
            int y1 = 2;
            int[] cord1;
            int x2 = 1;
            int y2 = 3;
            int[] cord2;
            int line = 1;
            using (StreamReader sr = new StreamReader("Day2Input.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string input = sr.ReadLine();
                    cord1 = LineMove1(x1, y1, input);
                    x1 = cord1[0];
                    y1 = cord1[1];
                    key1 = CordToKey1(x1, y1);
                    cord2 = LineMove2(x2, y2, input);
                    x2 = cord2[0];
                    y2 = cord2[1];
                    key2 = CordToKey2(x2, y2);
                    Console.WriteLine("Key1 #{0}: {1}   || Key2: {2}", line, key1, key2);
                    line++;
                }

            }
        }

        static int[] LineMove1(int x, int y, string move)
        {
            int position = 0;
            while (position < move.Length)
            {
                if (move[position].Equals('U') || move[position].Equals('D'))
                {
                    if (move[position].Equals('U'))
                    {
                        y--;
                        if (y <= 0)
                        {
                            y = 1;
                        }
                    }
                    else
                    {
                        y++;
                        if (y >= 4)
                        {
                            y = 3;
                        }
                    }
                }
                else
                {
                    if (move[position].Equals('L'))
                    {
                        x--;
                        if (x <= 0)
                        {
                            x = 1;
                        }
                    }
                    else
                    {
                        x++;
                        if (x >= 4)
                        {
                            x = 3;
                        }
                    }
                }
                position++;
            }
            int[] cord = { x, y };
            return cord;

        }

        static int[] LineMove2(int x, int y, string move)
        {
            int position = 0;
            while (position < move.Length)
            {
                if (move[position].Equals('U') || move[position].Equals('D'))
                {
                    if (move[position].Equals('U'))
                    {
                        y--;
                        if (x == 1 || x == 5)
                        {
                            y = 3;
                        } else if ((x == 2 || x == 4) && y <= 2)
                        {
                            y = 2;
                        } else if (x == 3 && y <= 1)
                        {
                            y = 1;
                        }
                    }
                    else
                    {
                        y++;
                        if (x == 1 || x == 5)
                        {
                            y = 3;
                        }
                        else if ((x == 2 || x == 4) && y >= 4)
                        {
                            y = 4;
                        }
                        else if (x == 3 && y >= 5)
                        {
                            y = 5;
                        }
                    }
                }
                else
                {
                    if (move[position].Equals('L'))
                    {
                        x--;
                        if (y == 1 || y == 5)
                        {
                            x = 3;
                        }
                        else if ((y == 2 || y == 4) && x <= 2)
                        {
                            x = 2;
                        }
                        else if (y == 3 && x <= 1)
                        {
                            x = 1;
                        }
                    }
                    else
                    {
                        x++;
                        if (y == 1 || y == 5)
                        {
                            x = 3;
                        }
                        else if ((y == 2 || y == 4) && x >= 4)
                        {
                            x = 4;
                        }
                        else if (y == 3 && x >= 5)
                        {
                            x = 5;
                        }
                    }
                }
                position++;
            }
            int[] cord = { x, y };
            return cord;

        }

        static char CordToKey1(int x, int y)
        {
            if (y == 1)
            {
                if (x == 1)
                {
                    return '1';
                }
                else if (x == 2)
                {
                    return '2';
                }
                else
                {
                    return '3';
                }
            }
            else if (y == 2)
            {
                if (x == 1)
                {
                    return '4';
                }
                else if (x == 2)
                {
                    return '5';
                }
                else 
                {
                    return '6';
                }
            }
            else 
            {
                if (x == 1)
                {
                    return '7';
                }
                else if (x == 2)
                {
                    return '8';
                }
                else
                {
                    return '9';
                }
            }
        }
        static char CordToKey2(int x, int y)
        {
            if (y == 1)
            {
                return '1';
            }
            else if (y == 2)
            {
                if (x == 2)
                {
                    return '2';
                }
                else if (x == 3)
                {
                    return '3';
                }
                else
                {
                    return '4';
                }
            }
            else if (y == 3)
            {
                if (x == 1)
                {
                    return '5';
                }
                else if (x == 2)
                {
                    return '6';
                }
                else if (x == 3)
                {
                    return '7';
                }
                else if (x == 3)
                {
                    return '8';
                }
                else
                {
                    return '9';
                }
            } else if (y == 4)
            {
                if (x == 2)
                {
                    return 'A';
                }
                else if (x == 3)
                {
                    return 'B';
                }
                else
                {
                    return 'C';
                }
            } else
            {
                return 'D';
            }
        }
    }
}
