using System;
namespace RecursiveTicTacToe.RecursiveTicTacToe
{
    public class Player
    {
        public String Name { get; private set; }
        public String Symbol { get; private set; }

        public Player(String name, String symbol)
        {
            Name = name;

            if (symbol.Length != 1)
            {
                throw new Exception("Player symbols must be exactly one character.");
            }

            Symbol = symbol;
        }
    }
}
