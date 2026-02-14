namespace CarShopFinal.Domain.Models;

public class Customer : AggregateRoot 
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    
    private Customer() { }
    
    public Customer(string firstName, string lastName, string email, string phoneNumber)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        
        SetCreatedAt();
    }
    
    public void UpdateContactInfo(string email, string phoneNumber)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        SetUpdatedAt();
    }
    
}