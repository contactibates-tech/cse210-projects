using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);

        string letter = "";
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign (+ or -)
        string sign = "";
        int lastDigit = percentage % 10;

        if (letter == "F")
        {
            sign = "";
        }
        else if (letter == "A" && lastDigit >= 7)
        {
            // No A+ allowed
            sign = "";
        }
        else
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }

        // Output the final grade
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Check if the user passed
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Better luck next time. Keep working hard!");
        }
    }
}