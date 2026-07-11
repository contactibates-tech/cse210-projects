using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                if (number == 0)
                {
                    break;
                }
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Core Requirements
        int sum = numbers.Sum();
        double average = (double)sum / numbers.Count;
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge 1: Smallest positive number
        var positiveNumbers = numbers.Where(n => n > 0).ToList();
        if (positiveNumbers.Any())
        {
            int smallestPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }

        // Stretch Challenge 2: Sorted list
        List<int> sortedNumbers = new List<int>(numbers);
        sortedNumbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int num in sortedNumbers)
        {
            Console.WriteLine(num);
        }
    }
}