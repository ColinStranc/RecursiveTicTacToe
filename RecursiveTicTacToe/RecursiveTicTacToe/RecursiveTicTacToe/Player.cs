using System;
namespace RecursiveTicTacToe.RecursiveTicTacToe
{
    public class Player
    {
        public String Name { get; private set; }
        public Char Symbol { get; private set; }

        public Player(String name, Char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
