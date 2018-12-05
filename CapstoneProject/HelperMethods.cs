using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject
{
    class HelperMethods
    {
        public static void DisplayWelcomeScreen(string title, string author, string purpose)
        {
            Console.Clear();
            Console.WriteLine($"\t\tWelcome to {title}, \n\t\tby {author}");
            Console.WriteLine($"\nThis program {purpose}");
            DisplayContinuePrompt();
        }

        public static void DisplayContinuePrompt()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public static void DisplayClosingScreen()
        {
            Console.WriteLine("\n\t\tThank you for using my App.");
            DisplayContinuePrompt();
        }

        public static void DisplayHeader(string headText)
        {
            Console.Clear();
            Console.WriteLine($"\n{headText}\n");
        }
    }
}
