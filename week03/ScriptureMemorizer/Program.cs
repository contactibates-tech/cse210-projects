// Creativity / Exceeding Requirements:
// 1. Only selects words that are not already hidden when choosing random words to hide
//    (stretch challenge from the requirements).
// 2. Maintains a small library of scriptures and randomly selects one each time the
//    program starts, so the user can practice different passages.
// 3. Hides a variable number of words each round (between 2 and 4 remaining words)
//    to keep the difficulty engaging rather than always hiding a fixed count.
// 4. Displays a simple progress indicator showing how many words remain visible.

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Library of scriptures (reference + text)
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("Psalm", 23, 1, 3),
                "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters. He restoreth my soul: he leadeth me in the paths of righteousness for his name's sake."
            ),
            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
            ),
            new Scripture(
                new Reference("Mosiah", 2, 17),
                "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."
            )
        };

        // Randomly select a scripture from the library
        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        // Main loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine($"Words remaining visible: {scripture.GetVisibleWordCount()}");
            Console.WriteLine();
            Console.Write("Press Enter to hide more words, or type 'quit' to exit: ");

            string input = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (input == "quit")
            {
                break;
            }

            // Hide a few random (still-visible) words
            int wordsToHide = Math.Min(random.Next(2, 5), scripture.GetVisibleWordCount());
            if (wordsToHide > 0)
            {
                scripture.HideRandomWords(wordsToHide);
            }

            // End when everything is hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("All words are now hidden. Great job practicing!");
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
                break;
            }
        }
    }
}

// ------------------------------------------------------------
// Reference class – handles single verse and verse ranges
// ------------------------------------------------------------
class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;   // -1 means single verse

    // Constructor for a single verse (e.g. "John 3:16")
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = -1;
    }

    // Constructor for a verse range (e.g. "Proverbs 3:5-6")
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse == -1)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}

// ------------------------------------------------------------
// Word class – represents one word and whether it is hidden
// ------------------------------------------------------------
class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Replace every letter with an underscore, keep any trailing punctuation
            // (simple approach: replace all letters, leave non-letters)
            char[] chars = _text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    chars[i] = '_';
                }
            }
            return new string(chars);
        }
        else
        {
            return _text;
        }
    }
}

// ------------------------------------------------------------
// Scripture class – holds the reference and the list of words
// ------------------------------------------------------------
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split on spaces and create Word objects
        string[] rawWords = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string w in rawWords)
        {
            _words.Add(new Word(w));
        }
    }

    public void HideRandomWords(int count)
    {
        // Only consider words that are not already hidden
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        if (visibleWords.Count == 0)
        {
            return;
        }

        Random random = new Random();
        int toHide = Math.Min(count, visibleWords.Count);

        // Shuffle and take the first 'toHide' words
        for (int i = 0; i < toHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // prevent selecting the same word twice in this round
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public int GetVisibleWordCount()
    {
        return _words.Count(w => !w.IsHidden());
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{referenceText}\n{scriptureText}";
    }
}