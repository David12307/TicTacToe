using System;

namespace TicTacToe
{
    internal class Program
    {
        static string RenderSquare(string square)
        {
            if (square == null)
            {
                return " [ ] ";
            }
            else
            {
                return square;
            }
        }

        static void RenderTable(string[] positions, int[] winnerPositions = null)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                if (winnerPositions == null)
                {
                    if (i != 2 && i != 5)
                    {
                        Console.Write(RenderSquare(positions[i]));
                    }
                    else
                    {
                        Console.Write(RenderSquare(positions[i]) + "\n");
                    }
                }
                else
                {
                    if (i != 2 && i != 5)
                    {
                        if (winnerPositions.Contains(i))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(RenderSquare(positions[i]));
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        if (winnerPositions.Contains(i))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(RenderSquare(positions[i]) + "\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }

        static int[] HasWon(string[] positions, string currentPlayer)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (positions[i] == currentPlayer && positions[i + 3] == currentPlayer && positions[i + 6] == currentPlayer)
                {
                    return new int[] { i, i + 3, i + 6 };
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (positions[i] == currentPlayer && positions[i + 1] == currentPlayer && positions[i + 2] == currentPlayer)
                {
                    return new int[] { i, i + 1, i + 2 };
                }
            }

            // Check diagonals
            if (positions[0] == currentPlayer && positions[4] == currentPlayer && positions[8] == currentPlayer)
            {
                return new int[] { 0, 4, 8 };
            }
            if (positions[2] == currentPlayer && positions[4] == currentPlayer && positions[6] == currentPlayer)
            {
                return new int[] { 2, 4, 6 };
            }

            return null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to tic tac toe!");

            string[] table = new string[]
            {
                null, null, null,
                null, null, null,
                null, null, null
            };

            string player = "X";
            bool playing = true;

            while (playing)
            {
                RenderTable(table);
                Console.WriteLine($"\n\n{player}'s round.");
                Console.WriteLine("Enter a digit from 1-9 (position on table)...");
                ConsoleKeyInfo tablePos = Console.ReadKey(true);
                int chosenPosition;
                if (char.IsDigit(tablePos.KeyChar))
                {
                    chosenPosition = int.Parse(tablePos.KeyChar.ToString());
                    if (chosenPosition <= 9 && chosenPosition >= 1)
                    {
                        if (table[chosenPosition - 1] == null)
                        {
                            table[chosenPosition - 1] = $" [{player}] ";
                            
                            if (HasWon(table, $" [{player}] ") != null)
                            {
                                RenderTable(table, HasWon(table, $" [{player}] "));
                                Console.WriteLine($"\n[{player}] won!");
                                playing = false;
                            }

                            player = player == "X" ? "0" : "X";
                        }
                        else
                        {
                            Console.WriteLine("Invalid input... Please enter a valid digit. \n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input... Please enter a valid digit. \n");
                    }
                } 
                else
                {
                    Console.WriteLine("Invalid input... Please enter a digit. \n");
                }
            }
        }
    }
}