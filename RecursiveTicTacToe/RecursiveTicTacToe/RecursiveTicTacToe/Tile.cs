using System;
using System.Collections.Generic;
using RecursiveTicTacToe.RecursiveTicTacToe.Exceptions;

namespace RecursiveTicTacToe.RecursiveTicTacToe
{
    public class Tile : AbstractTicTacToe
    {
        public Tile(IList<Player> _players)
            : base(_players)
        {
            
        }

        public override void Set(Coordinates coordinates, Player player)
        {
            if (coordinates != null)
            {
                throw new Exception("A tile should not be given coordinates to set to.");
            }

            if (owner != null)
            {
                throw new TicTacToeOwnedException(owner, player);
            }

            owner = player;
        }

        public override string ToString()
        {
            return owner == null ? " " : owner.Symbol;
        }
    }
}
