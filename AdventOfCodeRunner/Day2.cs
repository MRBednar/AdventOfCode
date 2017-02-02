using System;
using System.IO;

namespace AdventOfCodeRunner
{
    public class Day2 : IDay
    {
        public void Run()
        {
            char key = '5';
            int x = 1;
            int y = 3;
            int[] cord;
            int line = 1;
            using (StreamReader sr = new StreamReader("C:\\Users\\mbednar\\Desktop\\Day2Input.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string input = sr.ReadLine();
                    cord = LineMove(x, y, input);
                    x = cord[0];
                    y = cord[1];
                    key = CordToKey(x, y);
                    Console.WriteLine("Key #{0}: {1}", line, key);
                    line++;
                }

            }
        }

        static int[] LineMove(int x, int y, string move)
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

        static char CordToKey(int x, int y)
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
