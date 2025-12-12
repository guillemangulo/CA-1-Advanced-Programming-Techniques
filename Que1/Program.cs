using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        ContactBook cb = new ContactBook();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine("1: Add Contact");
            Console.WriteLine("2: Show All Contacts");
            Console.WriteLine("3: Show Contact Details");
            Console.WriteLine("4: Update Contact");
            Console.WriteLine("5: Delete Contact");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------------------------------------");
            Console.Write("Select option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddNewContact(cb);
                    break;
                case "2":
                    cb.ShowAllContacts();
                    break;
                case "3":
                    Console.Write("Enter mobile number or first name + last name to search (e.g 870000001 or Guillem Angulo): ");
                    cb.ShowContactDetails(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Enter mobile number or first name + last name to update (e.g 870000001 or Guillem Angulo): ");
                    cb.UpdateContact(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Enter mobile number or first name + last name to delete (e.g 870000001 or Guillem Angulo): ");
                    cb.DeleteContact(Console.ReadLine());
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void AddNewContact(ContactBook book)
    {
        Console.WriteLine("Enter the following required fields to create a new contact: \n");
        try
        {
            Console.Write("First Name: ");
            string fn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fn)) throw new Exception("First Name cannot be empty.");
            if (fn.Length < 2) throw new Exception("Please enter a real name");

            Console.Write("Last Name: ");
            string ln = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(ln)) throw new Exception("Last Name cannot be empty.");
            if (ln.Length < 2) throw new Exception("Please enter a real surname");

            Console.Write("Company: ");
            string comp = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(comp)) throw new Exception("Company cannot be empty.");

            Console.Write("Mobile (9 digits): ");
            string mob = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(mob)) throw new Exception("Mobile number cannot be empty.");
            if (mob.Length != 9) throw new Exception("Enter a 9 digits mobile phone");

            Console.Write("Email: ");
            string em = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(em)) throw new Exception("Email cannot be empty.");
            if (!em.Contains("@") || !em.Contains(".")) throw new Exception("Invalid email format. Must contain '@' and '.'.");


            Console.Write("Birthdate (yyyy-mm-dd): ");
            string dobInput = Console.ReadLine();
            
            
            if (!DateTime.TryParseExact(dobInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob))
            {
                throw new FormatException("Invalid date format.");
            }

            Contact newC = new Contact(fn, ln, comp, em, mob, dob);
            book.AddContact(newC);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}