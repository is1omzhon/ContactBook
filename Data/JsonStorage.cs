using System.Text.Json;
using ContactBook.Models;

namespace ContactBook.Data;

public static class JsonStorage
{
    private static readonly string _filePath = "conracts.json";

    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
      WriteIndented = true;  
    };

    public static void Save(List<Contact> contacts)
    {
        var json = JsonSerializer.Serialize(contacts, _options);
        File.WriteAllText(_filePath, json);
    }

    public static List<Contact> Load()
    {
        if(!File.Exists(_filePath))
            return new List<Contact>();
        
        var json = File.ReadAllText(_filePath);

        return JsonSerializer.Deserialize<List<Contact>>(json)
                ?? new List<Contact>();
    }

}