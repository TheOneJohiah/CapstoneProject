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
        Title: (title)
        Application Type: (framework – Console, WinForms, UWP, etc.)
        Description: (describe the purpose and function)
        Author: (your name)
        Date Created: (current date)
        Last Modified:
        ************************************/

        static void Main(string[] args)
        {
            string victor = 0;
            string moveType = "random";
            bool run = true;
            string[] places = new string[9];

            HelperMethods.DisplayWelcomeScreen("Tic Tac Toe", "Micah Thoreson", "allows you to play a game of tic tac toe with a friend.");
            DisplayMenu();
            GetMenuChoice();
            do
            {

            } while (run);
            BoardDisplay(places);

            Console.ReadLine();
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
