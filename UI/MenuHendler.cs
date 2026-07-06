using ContactBook.Models;
using ContactBook.Services;
using ContactBook.Validators;

namespace ContactBook.UI;

public class MenuHandler
{
    private readonly IContactService _service;

    public MenuHandler(IContactService service)
    {
        _service = service;
    }

    // Dastur ishga tushganda shu metod chaqiriladi
    public void Run()
    {
        while (true)
        {
            ShowMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddContact(); break;
                case "2": _service.GetAll(); break;
                case "3": GetById(); break;
                case "4": UpdateContact(); break;
                case "5": DeleteContact(); break;
                case "6": SearchContact(); break;
                case "7": _service.GetSorted(); break;
                case "8": FilterByCategory(); break;
                case "0":
                    Console.WriteLine("Dasturdan chiqildi. Xayr!");
                    return;
                default:
                    Console.WriteLine("Noto'g'ri tanlov! Qaytadan urinib ko'ring.");
                    break;
            }

            Console.WriteLine("\nDavom etish uchun Enter bosing...");
            Console.ReadLine();
        }
    }

    // Menyuni ekranga chiqarish
    private void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("===== KONTAKTLAR KITOBI =====");
        Console.WriteLine("1. Kontakt qo'shish");
        Console.WriteLine("2. Barcha kontaktlarni ko'rish");
        Console.WriteLine("3. Kontakt qidirish (ID bo'yicha)");
        Console.WriteLine("4. Kontaktni tahrirlash");
        Console.WriteLine("5. Kontaktni o'chirish");
        Console.WriteLine("6. Qidiruv (ism/telefon)");
        Console.WriteLine("7. Saralangan ko'rish (A-Z)");
        Console.WriteLine("8. Kategoriya bo'yicha filtr");
        Console.WriteLine("0. Chiqish");
        Console.WriteLine("==============================");
        Console.Write("Tanlovingiz: ");
    }

    // Kontakt qo'shish
    private void AddContact()
    {
        Console.Clear();
        Console.WriteLine("===== YANGI KONTAKT =====");

        string firstName;
        while (true)
        {
            Console.Write("Ism: ");
            firstName = Console.ReadLine() ?? "";

            if (ContactValidator.ValidateName(firstName, out string error))
                break;
            Console.WriteLine($"Xato: {error}");
        }

        string lastName;
        while (true)
        {
            Console.Write("Familiya: ");
            lastName = Console.ReadLine() ?? "";

            if (ContactValidator.ValidateName(lastName, out string error))
                break;
            Console.WriteLine($"Xato: {error}");
        }

        string phone;
        while (true)
        {
            Console.Write("Telefon: (+998 xx xxx xx xx) ");
            phone = Console.ReadLine() ?? "";

            if (ContactValidator.ValidatePhone(phone, out string error))
                break;

            Console.WriteLine($"Xato: {error}");
        }

        string email;
        while (true)
        {
            Console.Write("Email: ");
            email = Console.ReadLine() ?? "";

            if (ContactValidator.ValidateEmail(email, out string error))
                break;
            Console.WriteLine($"Xato: {error}");
        }

        var category = ChooseCategory();
        _service.AddContact(firstName, lastName, phone, email, category);
    }

    // ID bo'yicha qidirish
    private void GetById()
    {
        Console.Write("Kontakt ID sini kiriting: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            _service.GetById(id);
        }
        else
        {
            Console.WriteLine("Noto'g'ri ID format!");
        }
    }

    // Kontaktni tahrirlash
    private void UpdateContact()
    {
        Console.Write("Tahrirlash uchun ID kiriting: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Noto'g'ri ID format!");
            return;
        }

        Console.Clear();
        Console.WriteLine("===== KONTAKTNI TAHRIRLASH =====");

        Console.Write("Yangi ism: ");
        var firstName = Console.ReadLine() ?? "";

        Console.Write("Yangi familiya: ");
        var lastName = Console.ReadLine() ?? "";

        Console.Write("Yangi telefon: ");
        var phone = Console.ReadLine() ?? "";

        Console.Write("Yangi email: ");
        var email = Console.ReadLine() ?? "";

        var category = ChooseCategory();

        _service.Update(id, firstName, lastName, phone, email, category);
    }

    // Kontaktni o'chirish
    private void DeleteContact()
    {
        Console.Write("O'chirish uchun ID kiriting: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            _service.Delete(id);
        }
        else
        {
            Console.WriteLine("Noto'g'ri ID format!");
        }
    }

    // Kategoriya tanlash — yordamchi metod
    private Category ChooseCategory()
    {
        Console.WriteLine("Kategoriyani tanlang:");
        Console.WriteLine("1. Do'st");
        Console.WriteLine("2. Oila");
        Console.WriteLine("3. Ish");
        Console.WriteLine("4. Boshqa");
        Console.Write("Tanlov: ");

        return Console.ReadLine() switch
        {
            "1" => Category.Friend,
            "2" => Category.Family,
            "3" => Category.Work,
            _ => Category.Other
        };
    }

    private void SearchContact()
    {
        Console.Write("Qidiruv so'zi (ism yoki telefon): ");
        var keyword = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Qidiruv so'zi bo'sh bo'lishi mumkin emas!");
            return;
        }

        _service.Search(keyword);
    }

    private void FilterByCategory()
    {
        Console.WriteLine("Kategoriyani tanlang:");
        Console.WriteLine("1. Do'st");
        Console.WriteLine("2. Oila");
        Console.WriteLine("3. Ish");
        Console.WriteLine("4. Boshqa");
        Console.Write("Tanlov: ");

        var category = Console.ReadLine() switch
        {
          "1" => Category.Friend,
          "2" => Category.Family,
          "3" => Category.Work,
          _ => Category.Other  
        };

        _service.GetByCategory(category);
    }
}