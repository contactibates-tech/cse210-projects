using System;

namespace WelcomeProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcome();

            string userName = PromptUserName();
            int favoriteNumber = PromptUserNumber();

            int squaredNumber = SquareNumber(favoriteNumber);

            DisplayResult(userName, squaredNumber);
        }

        /// <summary>
        /// Displays the welcome message.
        /// </summary>
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        /// <summary>
        /// Prompts the user for their name and returns it.
        /// </summary>
        /// <returns>The user's name as a string.</returns>
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Prompts the user for their favorite number and returns it.
        /// </summary>
        /// <returns>The user's favorite number as an integer.</returns>
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Squares the given number and returns the result.
        /// </summary>
        /// <param name="number">The number to square.</param>
        /// <returns>The squared value.</returns>
        static int SquareNumber(int number)
        {
            return number * number;
        }

        /// <summary>
        /// Displays the final result with the user's name and squared number.
        /// </summary>
        /// <param name="name">The user's name.</param>
        /// <param name="squaredNumber">The squared favorite number.</param>
        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        }
    }
}