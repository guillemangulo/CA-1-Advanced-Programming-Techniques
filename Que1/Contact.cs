using System;
public class Contact {

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DoB { get; set; }

    public Contact(string firstName, string lastName, string company, string email, string phoneNumber, DateTime dob) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Company = company;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        this.DoB = dob;
    }

    public override string ToString()       
    {
        return $"Name: {FirstName} {LastName}\nPhone Number: {PhoneNumber}\nCompany: {Company}\nEmail: {Email}\nDate of Birth: {DoB.ToString("d MMM yyyy")}";
    }
}