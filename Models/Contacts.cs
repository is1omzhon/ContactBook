namespace ContactBook.Models;

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Category Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}