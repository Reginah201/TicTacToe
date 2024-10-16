using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
         private char[] board = { ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private int player = 1;
        private int choice;
        private int flag = 0;

        public void Run()
        {
            do
            {
                Console.Clear();
                DisplayBoard();
                if (player % 2 == 0)
                {
                    Console.WriteLine("Second Player's Turn (O)");
                }
                else
                {
                    Console.WriteLine("First player's Turn (X)");
                }

                // Get input and validate
                bool validInput = false;
                while (!validInput)
                {
                    Console.WriteLine("Choose a cell : ");
                    validInput = int.TryParse(Console.ReadLine(), out choice) &&
                                 choice >= 1 && choice <= 9 && 
                                 board[choice] != 'X' && board[choice] != 'O';
                    if (!validInput)
                    {
                        Console.WriteLine("Invalid move. Try again.");
                    }
                }

                // Update board with player choice
                if (player % 2 == 0)
                {
                    board[choice] = 'O';
                    player++;
                }
                else
                {
                    board[choice] = 'X';
                    player++;
                }

                flag = CheckWin();
            }
            while (flag == 0);

            Console.Clear();
            DisplayBoard();

            if (flag == 1)
            {
                Console.WriteLine($"Player {((player - 1) % 2 == 0 ? 2 : 1)} has won!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }

        private void DisplayBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[1]}  |  {board[2]}  |  {board[3]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[4]}  |  {board[5]}  |  {board[6]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[7]}  |  {board[8]}  |  {board[9]}");
            Console.WriteLine("     |     |      ");
        }

        private int CheckWin()
        {
            // Horizontal win conditions
            if (board[1] == board[2] && board[2] == board[3] ||
                board[4] == board[5] && board[5] == board[6] ||
                board[7] == board[8] && board[8] == board[9])
            {
                return 1;
            }

            // Vertical win conditions
            if (board[1] == board[4] && board[4] == board[7] ||
                board[2] == board[5] && board[5] == board[8] ||
                board[3] == board[6] && board[6] == board[9])
            {
                return 1;
            }

            // Diagonal win conditions
            if (board[1] == board[5] && board[5] == board[9] ||
                board[3] == board[5] && board[5] == board[7])
            {
                return 1;
            }

            // Check for draw
            if (board[1] != '1' && board[2] != '2' && board[3] != '3' &&
                board[4] != '4' && board[5] != '5' && board[6] != '6' &&
                board[7] != '7' && board[8] != '8' && board[9] != '9')
            {
                return -1;
            }

            // Game continues
            return 0;
        }
    }
}
