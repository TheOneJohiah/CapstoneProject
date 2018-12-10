using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject
{
    class Program
    {
        /************************************
        Title: Tic Tac Toe
        Application Type: ConsoleApp
        Description: Allows two players to play tic tac toe
        Author: Micah Thoreson
        Date Created: 12/3/2018
        Last Modified: 12/9/2018
        ************************************/

        // Define static variables (I don't know enough about classes to use them; this was the only other way)
        static string player1Name = "Player 1";
        static string player2Name = "Player 2";
        static string player1Letter = "X";
        static string player2Letter = "O";
        static int playerTurn = 0;

        static void Main(string[] args)
        {
            // Define variables
            string menuAnswer = null;
            string[] places = new string[9];

            // Explain the application
            HelperMethods.DisplayWelcomeScreen("Tic Tac Toe", "Micah Thoreson", "allows you to play a game of tic tac toe with a friend.");

            // Run the main section of the program
            do
            {
                // Display the main menu
                menuAnswer = DisplayMenu();
                ExecuteCommand(menuAnswer, places);
            } while (menuAnswer != "q");
            

            // Thank the user for playing; exit the program
            HelperMethods.DisplayClosingScreen();
        }

        private static void ExecuteCommand(string menuAnswer, string[] places)
        {
            HelperMethods.DisplayHeader("Main menu");
            switch (menuAnswer)
            {
                case "a":
                    player1Name = ChoosePlayerName(player1Name);
                    break;
                case "b":
                    player2Name = ChoosePlayerName(player2Name);
                    break;
                case "c":
                    player1Letter = ChoosePlayerSymbol(player1Letter, player1Name);
                    player2Letter = ChoosePlayerSymbol(player2Letter, player2Name);
                    while (player1Letter == player2Letter)
                    {
                        Console.WriteLine("Your letters cannot be identical! Please enter new letters.");
                        HelperMethods.DisplayContinuePrompt();
                        player1Letter = ChoosePlayerSymbol(player1Letter, player1Name, player2Letter);
                        player2Letter = ChoosePlayerSymbol(player2Letter, player2Name, player1Letter);
                    }
                    break;
                case "d":
                    playerTurn = 1;
                    Console.WriteLine($"The starting player is {player1Name}");
                    HelperMethods.DisplayContinuePrompt();
                    break;
                case "e":
                    playerTurn = 2;
                    Console.WriteLine($"The starting player is {player2Name}");
                    HelperMethods.DisplayContinuePrompt();
                    break;
                case "f":
                    playerTurn = ChooseStartingPlayer(playerTurn, player1Name, player2Name);
                    break;
                case "g":
                    DisplayRules();
                    break;
                case "h":
                    if (playerTurn == 0)
                    {
                        ChooseStartingPlayer(playerTurn, player1Name, player2Name);
                    }
                    PlayGame(places);
                    break;
                case "q":
                    break;
                default:
                    Console.WriteLine($"Sorry, {menuAnswer} is not a valid answer. Please choose only an option listed on the menu.");
                    HelperMethods.DisplayContinuePrompt();
                    break;
            }

        }

        private static void PlayGame(string[] places)
        {
            bool win = false;
            HelperMethods.DisplayHeader("Play the game");
            HelperMethods.DisplayContinuePrompt();
            do
            {
                BoardDisplay(places);
                Console.WriteLine("Current empty spaces:");
                for (int i = 0; i < 9; i++)
                {
                    if (places[i] == null)
                    {
                        Console.WriteLine(i+1);
                    }
                }

                if (playerTurn == 1)
                {
                    places = PlayerMove(player1Name, 2, places);
                }
                else if (playerTurn == 2)
                {
                    places = PlayerMove(player2Name, 1, places);
                }
                win = WinChecker()
                HelperMethods.DisplayContinuePrompt();
            } while (!win);
        }

        private static string[] PlayerMove(string playerName, int playerTurn, string[] places)
        {
            Console.WriteLine($"{playerName}'s turn! Enter a number to mark one of the empty spaces.");
            Console.WriteLine("The grid is 1-9, 1 being top left, 3 being top right, 7 bottom left, 9 bottom right.");

            return places;
        }

        private static string ChoosePlayerSymbol(string playerLetter, string playerName, string otherPlayerLetter)
        {
            bool validLetter = false;
            do
            {
                HelperMethods.DisplayHeader($"Choose X or O for {playerName}");
                Console.WriteLine($"\nThe other player has {otherPlayerLetter}");
                playerLetter = Console.ReadLine().ToUpper();
                if (playerLetter != "X" && playerLetter != "O")
                {
                    Console.WriteLine($"{playerLetter} is not a valid letter! Please try again.");
                    HelperMethods.DisplayContinuePrompt();
                }
                else
                {
                    validLetter = true;
                }
            } while (validLetter == false);
            Console.WriteLine($"Your letter is {playerLetter}");
            HelperMethods.DisplayContinuePrompt();
            return playerLetter;
        }

        private static void DisplayRules()
        {
            HelperMethods.DisplayHeader("The rules of Tic Tac Toe");

            Console.WriteLine("\nTic Tac Toe is a fairly simple game.");
            Console.WriteLine("The two players take turns filling the grid with their respective letter,");
            Console.WriteLine("and the first to get three in a row wins.");
            Console.WriteLine("If the grid fills without three in a row, there is no winner.");

            HelperMethods.DisplayContinuePrompt();
        }

        private static int ChooseStartingPlayer(int startPlayer, string player1Name, string player2Name)
        {
            Random rand = new Random();

            HelperMethods.DisplayHeader("Randomize the starting player");
            HelperMethods.DisplayContinuePrompt();
            Console.WriteLine("\nRandomizing...");
            System.Threading.Thread.Sleep(1000);
            startPlayer = rand.Next(1, 3);
            if (startPlayer == 1)
            {
                Console.WriteLine($"The starting player is {player1Name}");
            }
            else
            {
                Console.WriteLine($"The starting player is {player2Name}");
            }
            HelperMethods.DisplayContinuePrompt();
            return startPlayer;
        }

        private static string ChoosePlayerSymbol(string playerLetter, string playerName)
        {
            bool validLetter = false;
            do
            {
                HelperMethods.DisplayHeader($"Choose X or O for {playerName}");
                playerLetter = Console.ReadLine().ToUpper();
                if (playerLetter != "X" && playerLetter != "O")
                {
                    Console.WriteLine($"{playerLetter} is not a valid letter! Please try again.");
                    HelperMethods.DisplayContinuePrompt();
                }
                else
                {
                    validLetter = true;
                }
            } while (validLetter == false);
            Console.WriteLine($"Your letter is {playerLetter}");
            HelperMethods.DisplayContinuePrompt();
            return playerLetter;
        }

        private static string ChoosePlayerName(string playerName)
        {
            HelperMethods.DisplayHeader($"Choose a new name for {playerName}");
            playerName = Console.ReadLine();
            Console.WriteLine($"\nWelcome, {playerName}!");
            HelperMethods.DisplayContinuePrompt();
            return playerName;
        }

        private static string DisplayMenu()
        {
            HelperMethods.DisplayHeader("Main menu");

            string menuAnswer = null;
            Console.WriteLine("\nPlease enter a letter corresponding with one of the listed options");
            Console.WriteLine("A) Choose player 1 name");
            Console.WriteLine("B) Choose player 2 name");
            Console.WriteLine("C) Choose X or O");
            Console.WriteLine("D) Give player 1 first move");
            Console.WriteLine("E) Give player 2 first move");
            Console.WriteLine("F) Randomise first move");
            Console.WriteLine("G) View Tic Tac Toe rules");
            Console.WriteLine("H) Play a game!");
            Console.WriteLine("Q) Quit");
            menuAnswer = Console.ReadLine().ToLower();

            return menuAnswer;
        }

        private static void BoardDisplay(string[] places)
        {
            Console.WriteLine("\n      |     |      ");
            Console.WriteLine($"   {places[0]}".PadRight(6) + $"|  {places[1]}".PadRight(6) + $"|  {places[2]}");
            Console.WriteLine("      |     |      ");
            Console.WriteLine(" -----|-----|-----");
            Console.WriteLine("      |     |      ");
            Console.WriteLine($"   {places[3]}".PadRight(6) + $"|  {places[4]}".PadRight(6) + $"|  {places[5]}");
            Console.WriteLine("      |     |      ");
            Console.WriteLine(" -----|-----|-----");
            Console.WriteLine("      |     |      ");
            Console.WriteLine($"   {places[6]}".PadRight(6) + $"|  {places[7]}".PadRight(6) + $"|  {places[8]}");
            Console.WriteLine("      |     |      ");
        }
    }
}
