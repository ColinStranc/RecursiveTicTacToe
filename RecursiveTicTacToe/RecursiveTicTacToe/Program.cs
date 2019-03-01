using System;
using System.Collections.Generic;
using RecursiveTicTacToe.RecursiveTicTacToe;

namespace RecursiveTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            Player p1 = new Player("Steven", 'x');
            Player p2 = new Player("Timothy", 'o');
            IList<Player> players = new List<Player> {
                p1, p2
            };

            AbstractTicTacToe attt = new Tile(players);

            Console.WriteLine("Finished With an Astounding Lack of Errors");
        }
    }
}
