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

        static void Main(string[] args)
        {
            // Define variables
            string victor = null;
            string menuAnswer = null;
            string player1Name = "Player 1";
            string player2Name = "Player 2";
            string player1Letter = "X";
            string player2Letter = "O";
            int startPlayer = 0;
            string[] places = new string[9];

            // Explain the application
            HelperMethods.DisplayWelcomeScreen("Tic Tac Toe", "Micah Thoreson", "allows you to play a game of tic tac toe with a friend.");

            // Run the main section of the program
            do
            {
                // Display the main menu
                menuAnswer = DisplayMenu();
                ExecuteCommand(menuAnswer, player1Name, player2Name, player1Letter, player2Letter, victor, startPlayer, places);
            } while (menuAnswer != "q");
            

            // Thank the user for playing; exit the program
            HelperMethods.DisplayClosingScreen();
        }

        private static void ExecuteCommand(string menuAnswer, string player1Name, string player2Name, string player1Letter, string player2Letter, string victor, int startPlayer, string[] places)
        {
            switch (menuAnswer)
            {
                case "a":
                    player1Name = ChoosePlayerName(player1Name);
                    break;
                case "b":
                    player2Name = ChoosePlayerName(player2Name);
                    break;
                case "c":
                    player1Letter = ChoosePlayerSymbol(player1Letter);
                    if (player1Letter == player2Letter)
                    {
                        Console.WriteLine($"You will need to change {player2Letter}'s letter as well to play.");
                        player2Letter = ChoosePlayerSymbol(player2Letter);
                    }
                    break;
                case "d":
                    
                    break;
                default:
                    Console.WriteLine($"Sorry, {menuAnswer} is not a valid answer. Please choose only an option listed on the menu.");
                    HelperMethods.DisplayContinuePrompt();
                    break;
            }

        }

        private static string ChoosePlayerSymbol(string playerLetter, string playerName)
        {
            HelperMethods.DisplayHeader($"Choose a new letter for {playerName}");
            playerLetter = Console.ReadLine();
            return playerLetter;
        }

        private static string ChoosePlayerName(string playerName)
        {
            HelperMethods.DisplayHeader($"Choose a new name for {playerName}");
            playerName = Console.ReadLine();
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
            Console.WriteLine("D) Choose starting player");
            Console.WriteLine("Q) Quit");
            menuAnswer = Console.ReadLine().ToLower();

            return menuAnswer;
        }

        private static void BoardDisplay(string[] places)
        {
            Console.WriteLine("     |     |     |     |");
            Console.WriteLine($"     |  {places[0]}".PadRight(11) + $"|  {places[1]}".PadRight(6) + $"|  {places[2]}".PadRight(6) + "|");
            Console.WriteLine("     |     |     |     |");
            Console.WriteLine("-----|-----|-----|-----|-----");
            Console.WriteLine("     |     |     |     |");
            Console.WriteLine($"     |  {places[3]}".PadRight(11) + $"|  {places[4]}".PadRight(6) + $"|  {places[5]}".PadRight(6) + "|");
            Console.WriteLine("     |     |     |     |");
            Console.WriteLine("-----|-----|-----|-----|-----");
            Console.WriteLine("     |     |     |     |");
            Console.WriteLine($"     |  {places[6]}".PadRight(11) + $"|  {places[7]}".PadRight(6) + $"|  {places[8]}".PadRight(6) + "|");
            Console.WriteLine("     |     |     |     |");
        }
    }
}
