using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("How to Bake Sourdough Bread", "BakingWithSarah", 845);
        Video video2 = new Video("Introduction to C# Classes", "CodeMasterPro", 1260);
        Video video3 = new Video("10-Minute Morning Yoga Flow", "YogaWithMaya", 612);
        Video video4 = new Video("Building a PC from Scratch", "TechBuilder", 1845);

        // Add comments to video1
        video1.AddComment(new Comment("Alex Rivera", "This recipe worked perfectly! My loaf turned out amazing."));
        video1.AddComment(new Comment("Jordan Lee", "Could you do a video on whole wheat sourdough next?"));
        video1.AddComment(new Comment("Sam Patel", "The starter tips were super helpful. Thanks!"));
        video1.AddComment(new Comment("Taylor Kim", "I've been struggling with oven spring – this fixed it."));

        // Add comments to video2
        video2.AddComment(new Comment("Chris Morgan", "Clear explanation of abstraction. Really helpful for beginners."));
        video2.AddComment(new Comment("Riley Quinn", "Can you cover inheritance in the next video?"));
        video2.AddComment(new Comment("Jamie Torres", "Great examples. I finally understand encapsulation."));

        // Add comments to video3
        video3.AddComment(new Comment("Morgan Ellis", "Perfect for busy mornings. Feeling energized!"));
        video3.AddComment(new Comment("Casey Brooks", "Loved the modifications for beginners."));
        video3.AddComment(new Comment("Avery Chen", "Do you have a longer evening flow?"));
        video3.AddComment(new Comment("Jordan Blake", "This has become part of my daily routine."));

        // Add comments to video4
        video4.AddComment(new Comment("Drew Parker", "Excellent step-by-step guide. No issues with assembly."));
        video4.AddComment(new Comment("Skyler Reed", "What about cable management tips?"));
        video4.AddComment(new Comment("Hayden Wells", "Helped me choose the right parts for my budget."));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}