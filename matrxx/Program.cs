using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
 
namespace Matrix
{
 
    static class FallenString
    {
        static object locker = new object();
        static Random rnd = new Random();
 
        public static void DrawString(object x)
        {
            int stringLength = rnd.Next(5, Console.WindowHeight - 10);
            int pozX = (int) x;
            int pozY = rnd.Next(0, Console.WindowHeight - 2); 
            int currentY = 0; 
 
            for (int i = 0; i < stringLength; i++)
            {
                lock (locker)
                {
 

                    if (pozY == Console.WindowHeight - 1)
                    {
                        pozY = 0;
                        Console.SetCursorPosition(pozX, pozY);
                        currentY = pozY + 1;
                    }
                    else
                    {
                        Console.SetCursorPosition(pozX, pozY++);
                        currentY = pozY + 1;
                    }
 

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("{0}", Convert.ToChar(rnd.Next(100, 126)));
 
                    if (currentY > 3 && i >= 2)
                    {
                        Console.SetCursorPosition(pozX, currentY - 3);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", Convert.ToChar(rnd.Next(100, 126)));
 
                        Console.SetCursorPosition(pozX, currentY - 4);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("{0}", Convert.ToChar(rnd.Next(100, 126)));
                    }
                    else if (currentY <= 2)
                    {
                        Console.SetCursorPosition(pozX, currentY - 4 + Console.WindowHeight);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}", Convert.ToChar(rnd.Next(100, 126)));
 
                        Console.SetCursorPosition(pozX, currentY - 5 + Console.WindowHeight);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("{0}", Convert.ToChar(rnd.Next(100, 126)));
                    }
 
                    if (i == stringLength - 1)
                    {
                        if (pozY >= stringLength)
                        {
                            Console.SetCursorPosition(pozX, pozY - stringLength);
                            Console.Write(' ');
                            i--;
                        }
                        else
                        {
                            Console.SetCursorPosition(pozX, Console.WindowHeight - stringLength + pozY);
                            Console.Write(' ');
                            i--;
                        }
                    }
                    Thread.Sleep(0);
                }
            }
        }
    }

    class Program
    {
        public static void Main()
        {
        
            for (int i = 0; i <  Console.WindowWidth - 1;)
            {
                new Thread(new ParameterizedThreadStart(FallenString.DrawString)).Start((object) i);
                i +=2;
            }
           Console.ReadKey();
        }
    }  

}
