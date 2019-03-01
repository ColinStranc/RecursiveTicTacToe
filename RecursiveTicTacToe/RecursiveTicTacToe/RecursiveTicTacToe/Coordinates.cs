using System;
namespace RecursiveTicTacToe.RecursiveTicTacToe
{
    public class Coordinates
    {
        public Coordinates SubCoordinates { get { return subCoordinates; } }
        public int XCoordinate { get { return xCoordinate; }}
        public int YCoordinate { get { return yCoordinate; } }

        private Coordinates subCoordinates;
        private int xCoordinate;
        private int yCoordinate;

        public Coordinates(int _x, int _y)
        {
            subCoordinates = null;
            xCoordinate = _x;
            yCoordinate = _y;
        }

        public Coordinates(int _x, int _y, Coordinates _subCoordinates)
        {
            subCoordinates = _subCoordinates;
            xCoordinate = _x;
            yCoordinate = _y;
        }
    }
}
