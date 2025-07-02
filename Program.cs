using System;
using System.Collections.Generic;

class Program
{
    delegate (int R, int G, int B) Colors(string color);
    static void Main()
    {
        Colors getRGB = delegate (string colors)
        {
            Dictionary<string, (int, int, int)> Rainbow = new()
            {
                { "red", (255, 0, 0) },
                { "orange", (255, 165, 0) },
                { "yellow", (255, 255, 0) },
                { "green", (0, 128, 0) },
                { "blue", (0, 191, 255) },
                { "violet", (128, 0, 128) }
            };
            return Rainbow.TryGetValue(colors.ToLower(), out var rgb) ? rgb : (0, 0, 0);
        };
        Console.WriteLine("Enter color:");
        string input = Console.ReadLine();
        var (r, g, b) = getRGB(input);
        Console.WriteLine($"RGB: ({r},{g},{b})");
    }
}