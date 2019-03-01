using System;
namespace RecursiveTicTacToe.RecursiveTicTacToe.Exceptions
{
    public class TicTacToeOwnedException : Exception
    {
        public Player OwningPlayer { get { return owningPlayer; } }
        public Player TrespassingPlayer { get { return trespassingPlayer; } }

        private readonly Player owningPlayer;
        private readonly Player trespassingPlayer;

        public TicTacToeOwnedException(Player _owningPlayer, Player _trespassingPlayer)
        {
            owningPlayer = _owningPlayer;
            trespassingPlayer = _trespassingPlayer;
        }
    }
}
