using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        ExtensionsDB db = new ExtensionsDB();
        bool running = true;

        Console.WriteLine("--- File Extension Info System ---");
        Console.WriteLine("Type an extension (e.g., .mp4 or mp4) to get info");
        Console.WriteLine("Type 'exit' to quit.\n");

        while (running)
        {
            Console.Write("Enter extension: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid value.");
                continue;
            }

            if (input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                running = false;
            }
            else
            {
                string result = db.GetDescription(input);
                Console.WriteLine($"Result: {result}\n");
            }
        }
    }
}