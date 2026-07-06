using ContactBook.Models;
using ContactBook.Data;

namespace ContactBook.Services;

public class ContactService : IContactService
{
    private List<Contact> _contacts = new List<Contact>();
    private int _nextId = 1;

    public ContactService()
    {
        _contacts = JsonStorage.Load();

        if(_contacts.Count > 0)
            _nextId = _contacts.Max(c => c.Id) + 1;
    }

    public void AddContact(string firstName, string lastName, string phone, string email, Category category)
    {
        var contact = new Contact
        {
            Id = _nextId++,
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            Email = email,
            Category = category
        };

        _contacts.Add(contact);
        JsonStorage.Save(_contacts);
        Console.WriteLine($"{firstName} {lastName} kontaktlar kitobiga qushildi!");
    }

    public void Delete(int id)
    {
        var contact = _contacts.FirstOrDefault(c => c.Id == id);

        if (contact == null)
        {
            Console.WriteLine($"ID {id} bo'yicha contact topilmadi");
            return;
        }

        _contacts.Remove(contact);
        JsonStorage.Save(_contacts);
        Console.WriteLine($"{contact.FirstName} {contact.LastName} o'chirildi!");

    }

    public void GetAll()
    {
        if (_contacts.Count() == 0)
        {
            Console.WriteLine("Kontaklar yuq!");
            return;
        }

        foreach (var contact in _contacts)
        {
            PrintContact(contact);
        }
    }

    public Contact GetById(int id)
    {
        var contact = _contacts.FirstOrDefault(c => c.Id == id);

        if (contact == null)
        {
            Console.WriteLine($"ID {id} bo'yicha contact topilmadi");
            return null;
        }

        PrintContact(contact);
        return contact;
    }

    public void GetByCategory(Category category)
    {
        var results = _contacts
            .Where(c => c.Category == category)
            .ToList();
        
        if(results.Count == 0)
        {
            Console.WriteLine($"'{category}' kategoriyasida kontakt yuq!");
            return;
        }

        Console.WriteLine($"\n ===== {category.ToString().ToUpper()} KATEGORIYASI ");
        foreach(var contact in _contacts)
        {
            PrintContact(contact);
        }
    }
    public void GetSorted()
    {
        if(_contacts.Count == 0)
        {
            Console.WriteLine("Konatkrlat yuq!");
            return;
        }

        var sorted = _contacts
            .OrderBy(c => c.FirstName)
            .ThenBy(c => c.LastName)
            .ToList();
        
        Console.WriteLine("\n ===== KONTAKTLAR (A-Z) =====");
        foreach(var contact in _contacts)
        {
            PrintContact(contact);
        }
    }

    public void Search(string keyword)
    {
        var results = _contacts
            .Where(c => c.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        c.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase)|| 
                        c.Phone.Contains(keyword))
            .ToList();
        
        if (results.Count == 0)
        {
            Console.WriteLine($"'{keyword}' bo'yicha hech narsa topilmadi!");
            return;
        }

        Console.WriteLine($"\n ===== QIDIRUV NATIJALARI: '{keyword}' =====");
        foreach(var contact in _contacts)
        {
            PrintContact(contact);
        }
    }

    public void Update(int id, string firstName, string lastName, string phone, string email, Category category)
    {
        var updatedContact = _contacts.FirstOrDefault(c => c.Id == id);

        if (updatedContact == null)
        {
            Console.WriteLine($"ID {id} bo'yicha contact topilmadi");
            return;
        }

        updatedContact.FirstName = firstName;
        updatedContact.LastName = lastName;
        updatedContact.Phone = phone;
        updatedContact.Email = email;
        updatedContact.Category = category;

        Console.WriteLine($"{firstName} {lastName} kontakti muvaffaqiyatli yangilandi!");
    }

    private void PrintContact(Contact contact)
    {
        Console.WriteLine(
        $"""
        ---------------------
        ID         : {contact.Id}
        Ism        : {contact.FirstName} {contact.LastName}
        Telefon    : {contact.Phone}
        Email      : {contact.Email}
        Kategoriya : {contact.Category}
        Qo'shilgan : {contact.CreatedAt: dd.MM.yyyy}
        ---------------------    
        """);
    }

}