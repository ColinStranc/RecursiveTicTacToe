using System;
using System.Collections.Generic;

namespace RecursiveTicTacToe.RecursiveTicTacToe
{
    public abstract class AbstractTicTacToe
    {
        public Player Owner { get { return owner; }}

        protected IList<Player> players;
        protected Player owner;

        protected AbstractTicTacToe(IList<Player> _players)
        {
            players = _players;
            owner = null;
        }

        public abstract void Set(Coordinates coordinates, Player player);
        public virtual String GCR(Coordinates coordinates)
        {
            return " ";
        }
    }
}
