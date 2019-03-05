using System;
using System.Text;
using System.Collections.Generic;

namespace RecursiveTicTacToe.RecursiveTicTacToe
{
    public class NestedTicTacToe
    {
        public IList<Player> Players { get { return players; } }
        public Player ActivePlayer { get { return activePlayer; } }
        public int NextX { get { return nextX; } }
        public int NextY { get { return nextY; } }

        private readonly IList<Player> players;
        private readonly TicTacToe board;
        private readonly IList<Coordinates> history;

        private Player activePlayer;
        private int nextX;
        private int nextY;

        public NestedTicTacToe(Player player1, Player player2)
        {
            players = new List<Player> {
                player1, player2
            };

            activePlayer = player1;

            board = new TicTacToe(players, 2);

            nextX = -1;
            nextY = -1;

            history = new List<Coordinates>();
        }

        public bool SetMajorGridCoordinates(int x, int y)
        {
            if (nextX != -1 && nextY != -1)
            {
                return false;
            }

            if (SubSquareIsOwned(x, y))
            {
                return false;
            }

            nextX = x;
            nextY = y;

            return true;
        }

        public bool HasMajorGridCoordinates()
        {
            return nextX != -1 && nextY != -1;
        }

        public bool Move(int x, int y)
        {
            if (board.Owner != null)
            {
                throw new Exception("Cannot make a move when the game is over.");
            }

            if (nextX == -1 || nextY == -1)
            {
                throw new Exception("The primary coordinates have not been set.");
            }

            Coordinates coordinates = new Coordinates(nextX, nextY,
                                                      new Coordinates(x, y));

            board.Set(coordinates, activePlayer);

            history.Add(coordinates);

            if (board.Owner != null)
            {
                return true;
            }

            if (SubSquareIsOwned(x, y))
            {
                nextX = -1;
                nextY = -1;
            }
            else
            {
                nextX = x;
                nextY = y;
            }

            SwapActivePlayer();

            return false;
        }

        public Player GetWinner()
        {
            return board.Owner;
        }

        private void SwapActivePlayer()
        {
            activePlayer = players[0] == activePlayer ? players[1] : players[0];
        }

        private bool SubSquareIsOwned(int x, int y)
        {
            return board.SquareOwned(x, y);
        }

        public override string ToString()
        {
            TicTacToe b = board;

            StringBuilder sb = new StringBuilder();

            Coordinates c0000 = new Coordinates(0, 0, new Coordinates(0, 0));
            Coordinates c0001 = new Coordinates(0, 0, new Coordinates(0, 1));
            Coordinates c0002 = new Coordinates(0, 0, new Coordinates(0, 2));
            Coordinates c0010 = new Coordinates(0, 0, new Coordinates(1, 0));
            Coordinates c0011 = new Coordinates(0, 0, new Coordinates(1, 1));
            Coordinates c0012 = new Coordinates(0, 0, new Coordinates(1, 2));
            Coordinates c0020 = new Coordinates(0, 0, new Coordinates(2, 0));
            Coordinates c0021 = new Coordinates(0, 0, new Coordinates(2, 1));
            Coordinates c0022 = new Coordinates(0, 0, new Coordinates(2, 2));

            Coordinates c0100 = new Coordinates(0, 1, new Coordinates(0, 0));
            Coordinates c0101 = new Coordinates(0, 1, new Coordinates(0, 1));
            Coordinates c0102 = new Coordinates(0, 1, new Coordinates(0, 2));
            Coordinates c0110 = new Coordinates(0, 1, new Coordinates(1, 0));
            Coordinates c0111 = new Coordinates(0, 1, new Coordinates(1, 1));
            Coordinates c0112 = new Coordinates(0, 1, new Coordinates(1, 2));
            Coordinates c0120 = new Coordinates(0, 1, new Coordinates(2, 0));
            Coordinates c0121 = new Coordinates(0, 1, new Coordinates(2, 1));
            Coordinates c0122 = new Coordinates(0, 1, new Coordinates(2, 2));

            Coordinates c0200 = new Coordinates(0, 2, new Coordinates(0, 0));
            Coordinates c0201 = new Coordinates(0, 2, new Coordinates(0, 1));
            Coordinates c0202 = new Coordinates(0, 2, new Coordinates(0, 2));
            Coordinates c0210 = new Coordinates(0, 2, new Coordinates(1, 0));
            Coordinates c0211 = new Coordinates(0, 2, new Coordinates(1, 1));
            Coordinates c0212 = new Coordinates(0, 2, new Coordinates(1, 2));
            Coordinates c0220 = new Coordinates(0, 2, new Coordinates(2, 0));
            Coordinates c0221 = new Coordinates(0, 2, new Coordinates(2, 1));
            Coordinates c0222 = new Coordinates(0, 2, new Coordinates(2, 2));

            // --------------------------------------------------------------

            Coordinates c1000 = new Coordinates(1, 0, new Coordinates(0, 0));
            Coordinates c1001 = new Coordinates(1, 0, new Coordinates(0, 1));
            Coordinates c1002 = new Coordinates(1, 0, new Coordinates(0, 2));
            Coordinates c1010 = new Coordinates(1, 0, new Coordinates(1, 0));
            Coordinates c1011 = new Coordinates(1, 0, new Coordinates(1, 1));
            Coordinates c1012 = new Coordinates(1, 0, new Coordinates(1, 2));
            Coordinates c1020 = new Coordinates(1, 0, new Coordinates(2, 0));
            Coordinates c1021 = new Coordinates(1, 0, new Coordinates(2, 1));
            Coordinates c1022 = new Coordinates(1, 0, new Coordinates(2, 2));

            Coordinates c1100 = new Coordinates(1, 1, new Coordinates(0, 0));
            Coordinates c1101 = new Coordinates(1, 1, new Coordinates(0, 1));
            Coordinates c1102 = new Coordinates(1, 1, new Coordinates(0, 2));
            Coordinates c1110 = new Coordinates(1, 1, new Coordinates(1, 0));
            Coordinates c1111 = new Coordinates(1, 1, new Coordinates(1, 1));
            Coordinates c1112 = new Coordinates(1, 1, new Coordinates(1, 2));
            Coordinates c1120 = new Coordinates(1, 1, new Coordinates(2, 0));
            Coordinates c1121 = new Coordinates(1, 1, new Coordinates(2, 1));
            Coordinates c1122 = new Coordinates(1, 1, new Coordinates(2, 2));

            Coordinates c1200 = new Coordinates(1, 2, new Coordinates(0, 0));
            Coordinates c1201 = new Coordinates(1, 2, new Coordinates(0, 1));
            Coordinates c1202 = new Coordinates(1, 2, new Coordinates(0, 2));
            Coordinates c1210 = new Coordinates(1, 2, new Coordinates(1, 0));
            Coordinates c1211 = new Coordinates(1, 2, new Coordinates(1, 1));
            Coordinates c1212 = new Coordinates(1, 2, new Coordinates(1, 2));
            Coordinates c1220 = new Coordinates(1, 2, new Coordinates(2, 0));
            Coordinates c1221 = new Coordinates(1, 2, new Coordinates(2, 1));
            Coordinates c1222 = new Coordinates(1, 2, new Coordinates(2, 2));

            // --------------------------------------------------------------

            Coordinates c2000 = new Coordinates(2, 0, new Coordinates(0, 0));
            Coordinates c2001 = new Coordinates(2, 0, new Coordinates(0, 1));
            Coordinates c2002 = new Coordinates(2, 0, new Coordinates(0, 2));
            Coordinates c2010 = new Coordinates(2, 0, new Coordinates(1, 0));
            Coordinates c2011 = new Coordinates(2, 0, new Coordinates(1, 1));
            Coordinates c2012 = new Coordinates(2, 0, new Coordinates(1, 2));
            Coordinates c2020 = new Coordinates(2, 0, new Coordinates(2, 0));
            Coordinates c2021 = new Coordinates(2, 0, new Coordinates(2, 1));
            Coordinates c2022 = new Coordinates(2, 0, new Coordinates(2, 2));

            Coordinates c2100 = new Coordinates(2, 1, new Coordinates(0, 0));
            Coordinates c2101 = new Coordinates(2, 1, new Coordinates(0, 1));
            Coordinates c2102 = new Coordinates(2, 1, new Coordinates(0, 2));
            Coordinates c2110 = new Coordinates(2, 1, new Coordinates(1, 0));
            Coordinates c2111 = new Coordinates(2, 1, new Coordinates(1, 1));
            Coordinates c2112 = new Coordinates(2, 1, new Coordinates(1, 2));
            Coordinates c2120 = new Coordinates(2, 1, new Coordinates(2, 0));
            Coordinates c2121 = new Coordinates(2, 1, new Coordinates(2, 1));
            Coordinates c2122 = new Coordinates(2, 1, new Coordinates(2, 2));

            Coordinates c2200 = new Coordinates(2, 2, new Coordinates(0, 0));
            Coordinates c2201 = new Coordinates(2, 2, new Coordinates(0, 1));
            Coordinates c2202 = new Coordinates(2, 2, new Coordinates(0, 2));
            Coordinates c2210 = new Coordinates(2, 2, new Coordinates(1, 0));
            Coordinates c2211 = new Coordinates(2, 2, new Coordinates(1, 1));
            Coordinates c2212 = new Coordinates(2, 2, new Coordinates(1, 2));
            Coordinates c2220 = new Coordinates(2, 2, new Coordinates(2, 0));
            Coordinates c2221 = new Coordinates(2, 2, new Coordinates(2, 1));
            Coordinates c2222 = new Coordinates(2, 2, new Coordinates(2, 2));


            sb.AppendFormat("{0}|{1}|{2} | {3}|{4}|{5} | {6}|{7}|{8}\n", 
                            b.GCR(c0000), b.GCR(c0010), b.GCR(c0020),
                            b.GCR(c1000), b.GCR(c1010), b.GCR(c1020),
                            b.GCR(c2000), b.GCR(c2010), b.GCR(c2020));
            sb.AppendLine("----- | ----- | -----");
            sb.AppendFormat("{0}|{1}|{2} | {3}|{4}|{5} | {6}|{7}|{8}\n",
                            b.GCR(c0001), b.GCR(c0011), b.GCR(c0021),
                            b.GCR(c1001), b.GCR(c1011), b.GCR(c1021),
                            b.GCR(c2001), b.GCR(c2011), b.GCR(c2021));
            sb.AppendLine("----- | ----- | -----");
            sb.AppendFormat("{0}|{1}|{2} | {3}|{4}|{5} | {6}|{7}|{8}\n",
                            b.GCR(c0002), b.GCR(c0012), b.GCR(c0022),
                            b.GCR(c1002), b.GCR(c1012), b.GCR(c1022),
                            b.GCR(c2002), b.GCR(c2012), b.GCR(c2022));


            sb.AppendLine("      |       |      ");
            sb.AppendLine("---------------------");
            sb.AppendLine("      |       |      ");

            sb.AppendFormat("{0}|{1}|{2} | {3}|{4}|{5} | {6}|{7}|{8}\n",
                            b.GCR(c0100), b.GCR(c0110), b.GCR(c0120),
                            b.GCR(c1100), b.GCR(c1110), b.GCR(c1120),
                            b.GCR(c2100), b.GCR(c2110), b.GCR(c2120));
            sb.AppendLine("----- | ----- | -----");
            sb.AppendFormat("{0}|{1}|{2} | {3}|{4}|{5} | {6}|{7}|{8}\n",
                            b.GCR(c0101), b.GCR(c0111), b.GCR(c0121),
                            b.GCR(c1101), b.GCR(c1111), b.GCR(c1121),
                            b.GCR(c2101), b.GCR(c2111), b.GCR(c2121));
            sb.AppendLine("----- | ----- | -----");
            sb.AppendFormat("{0}|{1}|{2} | {3}|{4}|{5} | {6}|{7}|{8}\n",
                            b.GCR(c0102), b.GCR(c0112), b.GCR(c0122),
                            b.GCR(c1102), b.GCR(c1112), b.GCR(c1122),
                            b.GCR(c2102), b.GCR(c2112), b.GCR(c2122));

            sb.AppendLine("      |       |      ");
            sb.AppendLine("---------------------");
            sb.AppendLine("      |       |      ");

            sb.AppendFormat("{0}|{1}|{2} | {3}|{4}|{5} | {6}|{7}|{8}\n",
                            b.GCR(c0200), b.GCR(c0210), b.GCR(c0220),
                            b.GCR(c1200), b.GCR(c1210), b.GCR(c1220),
                            b.GCR(c2200), b.GCR(c2210), b.GCR(c2220));
            sb.AppendLine("----- | ----- | -----");
            sb.AppendFormat("{0}|{1}|{2} | {3}|{4}|{5} | {6}|{7}|{8}\n",
                            b.GCR(c0201), b.GCR(c0211), b.GCR(c0221),
                            b.GCR(c1201), b.GCR(c1211), b.GCR(c1221),
                            b.GCR(c2201), b.GCR(c2211), b.GCR(c2221));
            sb.AppendLine("----- | ----- | -----");
            sb.AppendFormat("{0}|{1}|{2} | {3}|{4}|{5} | {6}|{7}|{8}",
                            b.GCR(c0202), b.GCR(c0212), b.GCR(c0222),
                            b.GCR(c1202), b.GCR(c1212), b.GCR(c1222),
                            b.GCR(c2202), b.GCR(c2212), b.GCR(c2222));

            return sb.ToString();
        }
    }
}
