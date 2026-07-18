using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    // Entry class - represents a single journal entry
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public override string ToString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
        }

        // Format for saving to file (using | as separator)
        public string ToFileString()
        {
            // Simple escaping: replace | with [PIPE] to avoid separator conflicts
            string safePrompt = Prompt.Replace("|", "[PIPE]");
            string safeResponse = Response.Replace("|", "[PIPE]");
            return $"{Date}|{safePrompt}|{safeResponse}";
        }

        // Create Entry from file line
        public static Entry FromFileString(string line)
        {
            string[] parts = line.Split('|');
            if (parts.Length >= 3)
            {
                string date = parts[0];
                string prompt = parts[1].Replace("[PIPE]", "|");
                string response = parts[2].Replace("[PIPE]", "|");
                return new Entry(date, prompt, response);
            }
            return null;
        }
    }

    // Journal class - manages a collection of entries
    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();
        private List<string> _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is one thing I learned today?",
            "How did I serve someone else today?",
            "What am I grateful for right now?"
        };

        public void AddEntry()
        {
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];

            Console.WriteLine($"\nPrompt: {prompt}");
            Console.Write("> ");
            string response = Console.ReadLine();

            string date = DateTime.Now.ToShortDateString();

            Entry entry = new Entry(date, prompt, response);
            _entries.Add(entry);

            Console.WriteLine("\nEntry added successfully!");
        }

        public void DisplayJournal()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("\nThe journal is empty.");
                return;
            }

            Console.WriteLine("\n=== Journal Entries ===");
            foreach (Entry entry in _entries)
            {
                Console.WriteLine(entry.ToString());
                Console.WriteLine("-------------------");
            }
        }

        public void SaveToFile()
        {
            Console.Write("\nEnter filename to save (e.g., journal.txt): ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    foreach (Entry entry in _entries)
                    {
                        outputFile.WriteLine(entry.ToFileString());
                    }
                }
                Console.WriteLine($"Journal saved to {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            Console.Write("\nEnter filename to load (e.g., journal.txt): ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            try
            {
                _entries.Clear(); // Replace current entries
                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Entry entry = Entry.FromFileString(line);
                        if (entry != null)
                        {
                            _entries.Add(entry);
                        }
                    }
                }
                Console.WriteLine($"Journal loaded from {filename} ({_entries.Count} entries)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            Console.WriteLine("Welcome to the Journal Program!");

            while (running)
            {
                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        journal.AddEntry();
                        break;
                    case "2":
                        journal.DisplayJournal();
                        break;
                    case "3":
                        journal.SaveToFile();
                        break;
                    case "4":
                        journal.LoadFromFile();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}