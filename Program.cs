using ContactBook.Models;
using ContactBook.Services;
using ContactBook.UI;

IContactService service = new ContactService();

MenuHandler menu = new MenuHandler(service);
menu.Run();