using System;
using System.Collections.Generic;

using RecursiveTicTacToe.RecursiveTicTacToe.Exceptions;

namespace RecursiveTicTacToe.RecursiveTicTacToe
{
    public class TicTacToe : AbstractTicTacToe
    {
        public const int DIMENSION = 3;

        private readonly IList<AbstractTicTacToe> squares;

        public TicTacToe(IList<Player> _players, int depth)
            : base(_players)
        {
            if (depth <= 0)
            {
                throw new Exception("TicTacToe game cannot be started at depth 0");
            }

            squares = new List<AbstractTicTacToe>();

            if (depth == 1)
            {
                for (int i = 0; i < DIMENSION*DIMENSION; i++)
                {
                    AbstractTicTacToe square = new Tile(players);
                    squares.Add(square);
                }
            }
            else
            {
                for (int i = 0; i < DIMENSION*DIMENSION; i++)
                {
                    AbstractTicTacToe square = new TicTacToe(players, depth - 1);
                    squares.Add(square);
                }
            }
        }

        public override void Set(Coordinates coordinates, Player player)
        {
            if (!Valid(coordinates))
            {
                throw new Exception("Invalid Coordinates");
            }

            AbstractTicTacToe square = GetSquare(coordinates);

            if (owner != null)
            {
                throw new TicTacToeOwnedException(owner, player);
            }

            square.Set(coordinates.SubCoordinates, player);

            if (square.Owner != null)
            {
                Player newOwner = FindOwner();
                if (newOwner != null)
                {
                    owner = newOwner;
                }
            }
        }

        public override String GCR(Coordinates coordinates)
        {
            if (coordinates.SubCoordinates == null)
            {
                return GetSquare(coordinates).ToString();
            }

            return GetSquare(coordinates).GCR(coordinates.SubCoordinates);
        }

        public bool SquareOwned(int x, int y)
        {
            return GetSquare(x, y).Owner != null;
        }

        private bool Valid(Coordinates coordinates)
        {
            if (coordinates.XCoordinate < 0 || coordinates.YCoordinate < 0)
            {
                return false;
            }

            int largestCoordinate = Math.Max(coordinates.XCoordinate, coordinates.YCoordinate);
            if (largestCoordinate+1 > DIMENSION)
            {
                return false;
            }

            return true;
        }

        private AbstractTicTacToe GetSquare(Coordinates coordinates)
        {
            return GetSquare(coordinates.XCoordinate, coordinates.YCoordinate); 
        }

        private AbstractTicTacToe GetSquare(int x, int y)
        {
            return squares[y * DIMENSION + x];
        }

        private Player FindOwner()
        {
            // I'm so sad I'm about to do this...

            Player o1 = squares[0].Owner;
            Player o2 = squares[1].Owner;
            Player o3 = squares[2].Owner;
            Player o4 = squares[3].Owner;
            Player o5 = squares[4].Owner;
            Player o6 = squares[5].Owner;
            Player o7 = squares[6].Owner;
            Player o8 = squares[7].Owner;
            Player o9 = squares[8].Owner;

            if (o1 != null && o1 == o2 && o1 == o3)
            {
                return o1;
            }

            if (o4 != null && o4 == o5 && o4 == o6)
            {
                return o4;
            }

            if (o7 != null && o7 == o8 && o7 == o9)
            {
                return o7;
            }

            if (o1 != null && o1 == o4 && o1 == o7)
            {
                return o1;
            }

            if (o2 != null && o2 == o5 && o2 == o8)
            {
                return o2;
            }

            if (o3 != null && o3 == o6 && o3 == o9)
            {
                return o3;
            }

            if (o1 != null && o1 == o5 && o1 == o9)
            {
                return o1;
            }

            if (o3 != null && o3 == o5 && o3 == o7)
            {
                return o3;
            }

            return null;
        }
    }
}
