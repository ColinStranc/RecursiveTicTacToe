using System;
using System.Collections.Generic;
using RecursiveTicTacToe.RecursiveTicTacToe;
using RecursiveTicTacToe.ConsoleNestedTicTacToe;

namespace RecursiveTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            RunConsoleNestedTicTacToe();

            // RunNestedTicTacToe();

            Console.WriteLine("Finished With an Astounding Lack of Errors");
        }

        static void RunConsoleNestedTicTacToe()
        {
            ConsoleTicTacToe cttt = new ConsoleTicTacToe();
            cttt.Start();
        }

        static void RunNestedTicTacToe()
        {
            Player p1 = new Player("Steven", "x");
            Player p2 = new Player("Timothy", "o");

            NestedTicTacToe nttt = new NestedTicTacToe(p1, p2);

            Console.WriteLine();

            Console.WriteLine(nttt);

            Console.WriteLine();
            Console.WriteLine("##############################################");
            Console.WriteLine();

            nttt.Move(1, 0);
            Console.WriteLine(nttt);

            Console.WriteLine();
            Console.WriteLine("##############################################");
            Console.WriteLine();

            nttt.Move(1, 1);
            Console.WriteLine(nttt);

            Console.WriteLine();
            Console.WriteLine("##############################################");
            Console.WriteLine();

            nttt.Move(0, 0);
            Console.WriteLine(nttt);

            Console.WriteLine();
            Console.WriteLine("##############################################");
            Console.WriteLine();

            nttt.Move(2, 2);
            Console.WriteLine(nttt);

            Console.WriteLine();
            Console.WriteLine("##############################################");
            Console.WriteLine();

            nttt.Move(2, 1);
            Console.WriteLine(nttt);

            Console.WriteLine();
            Console.WriteLine("##############################################");
            Console.WriteLine();

            nttt.Move(1, 0);
            Console.WriteLine(nttt);

            Console.WriteLine();
        }
    }
}
