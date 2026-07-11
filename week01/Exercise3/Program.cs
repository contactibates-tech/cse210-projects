using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Generate random magic number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("I'm thinking of a magic number between 1 and 100...");

            // Game loop - continue until the user guesses correctly
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                // Basic validation
                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Stretch: Show number of guesses
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Stretch: Ask to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine() ?? "no";
        }

        Console.WriteLine("Thanks for playing!");
    }
}