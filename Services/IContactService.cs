using ContactBook.Models;

namespace ContactBook.Services;

public interface IContactService
{
    void AddContact(string firstName, string lastName, 
                    string phone, string email, Category category);
    void GetAll();
    Contact ? GetById(int id);
    void Update(int id, string firstName, string lastName,
                string phone, string email, Category category);
    void Delete(int id);

    void Search(string keyword);
    void GetSorted();
    void GetByCategory(Category category);
}