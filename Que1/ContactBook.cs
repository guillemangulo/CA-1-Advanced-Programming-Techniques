public class ContactBook {
    private List<Contact> _contacts;

    public ContactBook()       
    {
        _contacts = new List<Contact>();
        LoadContacts();         
    }

    private void LoadContacts() 
    {
        string[] firstNames = { "James", "Mary", "Robert", "Patricia", "John", "Jennifer", "Michael", "Linda", "David", "Elizabeth", "William", "Barbara", "Richard", "Susan", "Joseph", "Jessica", "Thomas", "Sarah", "Charles", "Karen" };
        string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin" };
        string[] companies = { "DBS", "Google", "Microsoft", "Amazon", "Facebook", "Apple", "Tesla", "Netflix", "Intel", "IBM", "DBS", "Oracle", "Cisco", "Adobe", "DBS", "Salesforce", "HP", "Dell", "Sony", "Samsung" };

        for (int i = 0; i < 20; ++i)
        {
            // Note: Since we don't have validation logic in the Property set yet, 
            // simple numbers work fine. If you add validation later, ensure this format matches it.
            string phNum = (870000000 + i).ToString();
            string emailAddress = $"{firstNames[i].ToLower()}.{lastNames[i].ToLower()}@CA1example.com";   
            DateTime birth = new DateTime(1980 + (i % 20), 1 + (i % 12), 1 + (i % 28));

            _contacts.Add(new Contact(
                firstNames[i],
                lastNames[i],
                companies[i],
                emailAddress,
                phNum,
                birth
            ));
        }
    }

    public void AddContact(Contact c) 
    {
        _contacts.Add(c);
        Console.WriteLine("Contact added successfully!");  
    }

    public void ShowAllContacts() 
    {
        Console.WriteLine("Showing all contacts...\n");
        // Fixed: .Count is a property for List, not a method .Count()
        for(int i = 0; i < _contacts.Count; ++i)
        {
            Console.WriteLine("\n" + _contacts[i].ToString());
        }
    }

    /*

    I implemented two ways to find a contact:
        1. By phone number
        2. By first name + last name
        
    */
    
    public Contact FindContact(string phNum) 
    {
        return _contacts.FirstOrDefault(contact => contact.PhoneNumber == phNum);
    }

    public Contact FindContact(string fn, string ln)
    {
        return _contacts.FirstOrDefault(contact => 
            contact.FirstName.Equals(fn) && 
            contact.LastName.Equals(ln));
    }

    public void ShowContactDetails(string searchTerm) 
    {
        // first try with mobile
        Contact contact = FindContact(searchTerm);
       
        // second try first + last name
        if (contact == null && searchTerm.Contains(" "))    // if contains a space, probably is {firstName} {lastName}
        {
            var parts = searchTerm.Split(" ");
            
            if (parts.Length >= 2)
            {
                string firstName = parts[0];
                string lastName = parts[1];
                contact = FindContact(firstName, lastName);
            }
        }

       
       if (contact != null)
        {
            Console.WriteLine($"\n--- Details for {contact.FirstName} ---");
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"Company: {contact.Company}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Date of Birth: {contact.DoB.ToString("d MMM yyyy")}");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }

    public void UpdateContact(string searchTerm)
    {
           // first try with mobile
        Contact contact = FindContact(searchTerm);
       
        // second try first + last name
        if (contact == null && searchTerm.Contains(" "))    // if contains a space, probably is {firstName} {lastName}
        {
            var parts = searchTerm.Split(" ");
            
            if (parts.Length >= 2)
            {
                string firstName = parts[0];
                string lastName = parts[1];
                contact = FindContact(firstName, lastName);
            }
        }
        if (contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        Console.WriteLine("Found contact. Enter new details (press Enter to skip):");
        
        Console.Write("New Company: ");
        string newComp = Console.ReadLine();
        if (!string.IsNullOrEmpty(newComp)) contact.Company = newComp;

        Console.Write("New Email: ");
        string newEmail = Console.ReadLine();
        if (!string.IsNullOrEmpty(newEmail)) contact.Email = newEmail;
        
        Console.WriteLine("Contact updated.");
    }

    public void DeleteContact(string searchTerm)
    {
        // first try with mobile
        Contact contact = FindContact(searchTerm);
       
        // second try first + last name
        if (contact == null && searchTerm.Contains(" "))    // if contains a space, probably is {firstName} {lastName}
        {
            var parts = searchTerm.Split(" ");
            
            if (parts.Length >= 2)
            {
                string firstName = parts[0];
                string lastName = parts[1];
                contact = FindContact(firstName, lastName);
            }
        }
        if (contact != null)
        {
            _contacts.Remove(contact);
            Console.WriteLine("Contact deleted successfully.");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }
}