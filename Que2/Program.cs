//entry point of the program
class Program
{
    static void Main(string[] args)
    {
        ExtensionsDB db = new ExtensionsDB();
        bool running = true;

        Console.WriteLine("Welcome to File extension info system!");
        Console.WriteLine("In case you want to quit, type 'exit'\n");

        while (running)
        {
            Console.Write("Enter extension (e.g .mp4 or mp4): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid value.");
                continue;
            }

            if (input.Equals("exit"))
            {
                running = false;
            }
            else
            {
                string result = db.GetDescription(input);
                Console.WriteLine($"{result}\n");
            }
        }
    }
}