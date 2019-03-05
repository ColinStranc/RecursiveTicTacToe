using System;
using System.Collections.Generic;

using RecursiveTicTacToe.RecursiveTicTacToe;
using RecursiveTicTacToe.RecursiveTicTacToe.Exceptions;

namespace RecursiveTicTacToe.ConsoleNestedTicTacToe
{
    public class ConsoleTicTacToe
    {
        private NestedTicTacToe game;

        public void Start()
        {
            IList<Player> players = GatherPlayers();

            game = new NestedTicTacToe(players[0], players[1]);

            Console.WriteLine("Excellent! Let's begin.");

            while (game.GetWinner() == null)
            {
                ExecuteTurn();
            }

            Console.WriteLine(String.Format("Congratulations! {0} won!", game.GetWinner().Name));
        }

        private IList<Player> GatherPlayers()
        {
            String p1Symbol = "x";
            String p2Symbol = "o";

            Console.Write("Enter Player 'x': ");
            String p1Name = Console.ReadLine();

            if (p1Name == "Zorro")
            {
                p1Symbol = "z";
            }

            Console.Write("Enter Player 'o': ");
            String p2Name = Console.ReadLine();

            return new List<Player> {
                new Player(p1Name, p1Symbol),
                new Player(p2Name, p2Symbol)
            };
        }

        private void ExecuteTurn()
        {
            Console.WriteLine(game);

            int x = game.NextX;
            int y = game.NextY;

            if (!game.HasMajorGridCoordinates())
            {
                Console.Write("You have a choice of grid to play in! Enter \"{x} {y}\": ");
                if (!GetCoordinatePair(out x, out y))
                {
                    // Coordinates were bad, start turn again.
                    return;
                }

                if (!game.SetMajorGridCoordinates(x, y))
                {
                    return;
                }
            }

            String heightText = y == 0 ? "top" : y == 1 ? "middle" : "bottom";
            String sideText = x == 0 ? "left" : x == 1 ? "middle" : "right";

            String quadrantText = heightText + " " + sideText;
            if (x == 1 && y == 1)
            {
                quadrantText = "middle";
            }

            Console.WriteLine(String.Format("{0} is next to act. They will be moving in the {1}.", game.ActivePlayer.Name, quadrantText));
            Console.Write("Enter you x coordinate (between 0 and 2) followed by your y coordinate on this line: ");

            if (!GetCoordinatePair(out int newX, out int newY))
            {
                // Coordinates were bad, start turn again.
                return;
            }

            try
            {
                game.Move(newX, newY);
            }
            catch(TicTacToeOwnedException tttoe)
            {
                Console.WriteLine(String.Format("That area is already filled by {0}, please try again.", tttoe.OwningPlayer.Name));
            }
        }

        private bool GetCoordinatePair(out int x, out int y)
        {
            String coordinatesText = Console.ReadLine();

            String[] coordinatesStringArray = coordinatesText.Split(" ");

            if (coordinatesStringArray.Length != 2)
            {
                Console.WriteLine("You didn't do that right. Let's do this again.");
                x = y = -1;
                return false;
            }

            int newX = -1;
            int newY = -1;

            if (!int.TryParse(coordinatesStringArray[0], out newX) ||
                !int.TryParse(coordinatesStringArray[1], out newY))
            {
                Console.WriteLine("You didn't do that right. Let's do this again.");
                x = y = -1;
                return false;
            }

            if (newX < 0 || newX > 2 || newY < 0 || newY > 2)
            {
                Console.WriteLine("You didn't do that right. Let's do this again.");
                x = y = -1;
                return false;
            }

            x = newX;
            y = newY;
            return true;
        }
    }
}
