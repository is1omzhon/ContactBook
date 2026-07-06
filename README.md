# 📒 ContactBook

A C# Console application for managing personal contacts.

## 🚀 Features

- ✅ Add contact (first name, last name, phone, email, category)
- ✅ View all contacts
- ✅ Search by ID
- ✅ Search by name or phone number
- ✅ Alphabetical sorting (A-Z)
- ✅ Filter by category
- ✅ Edit and delete contacts
- ✅ JSON file storage (data persists after closing the app)
- ✅ Input validation (name, phone format, email format)

## 🛠 Tech Stack

- C# 12
- .NET 8
- System.Text.Json
- OOP + Interface + Clean Code

## 📁 Project Structure

```
ContactBook/
├── Models/
│   ├── Contact.cs          → Main model
│   └── Category.cs         → Category enum
├── Services/
│   ├── IContactService.cs  → Interface
│   └── ContactService.cs   → Business logic
├── UI/
│   └── MenuHandler.cs      → User interface
├── Validators/
│   └── ContactValidator.cs → Input validation
├── Data/
│   └── JsonStorage.cs      → JSON save/load
└── Program.cs
```