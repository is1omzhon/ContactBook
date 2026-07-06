namespace ContactBook.Validators;

public static class ContactValidator
{
    public static bool ValidateName(string name, out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            errorMessage = "Ism bo'sh bo'lishi mumkin emas!";
            return false;
        }

        if(name.Length < 2)
        {
            errorMessage = "Ism kamida 2ta harf bo'lish kerak!";
            return false;
        }

        if(name.Any(c => char.IsDigit(c)))
        {
            errorMessage = "Ismda raqam bo'lishi mumkin emas!";
            return false;
        }
        errorMessage = "";
        return true;
    }

    public static bool ValidatePhone(string phone, out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            errorMessage = "Ism bo'sh bo'lishi mumkin emas!";
            return false;
        }

        if(!phone.StartsWith("+998") || phone.Length != 13 ||
            !phone.Skip(1).All(char.IsDigit))
        {
            errorMessage = "Telefon formati noto'g'ri! Misol: +998 90 123 45 67";
            return false;
        }

        errorMessage = "";
        return true;
    }

    public static bool ValidateEmail(string email, out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            errorMessage = "Email bo'sh bo'lishi mumkin emas!";
            return false;
        }

        if(!email.Contains("@") || !email.Contains("."))
        {
            errorMessage = "Email formati noto'g'ri! Misol: jasur@gmail.com";
            return false;
        }

        errorMessage = "";
        return true;

    }
}