# 📒 ContactBook

Kontaktlarni boshqarish uchun C# Console ilovasi.

## 🚀 Imkoniyatlar

- ✅ Kontakt qo'shish (ism, familiya, telefon, email, kategoriya)
- ✅ Barcha kontaktlarni ko'rish
- ✅ ID bo'yicha qidirish
- ✅ Ism va telefon bo'yicha qidiruv
- ✅ A-Z saralash
- ✅ Kategoriya bo'yicha filtr
- ✅ Kontaktni tahrirlash va o'chirish
- ✅ JSON faylda saqlash (dastur yopilsa ham yo'qolmaydi)
- ✅ Validatsiya (ism, telefon, email formati tekshiruvi)

## 🛠 Texnologiyalar

- C# 12
- .NET 8
- System.Text.Json
- OOP + Interface + Clean Code

## 📁 Loyiha tuzilmasi
### ContactBook/
### ├── Models/
### │   ├── Contact.cs          → Asosiy model
### │   └── Category.cs         → Kategoriya enum
### ├── Services/
### │   ├── IContactService.cs  → Interface
### │   └── ContactService.cs   → Biznes logika
### ├── UI/
### │   └── MenuHandler.cs      → Foydalanuvchi interfeysi
### ├── Validators/
### │   └── ContactValidator.cs → Ma'lumot tekshiruvi
### ├── Data/
### │   └── JsonStorage.cs      → JSON saqlash/yuklash
### └── Program.cs