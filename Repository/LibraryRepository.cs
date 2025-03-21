using System.Text.Json;
using System.Text.Json.Serialization;
using cs_lms.Constants;
using cs_lms.Enum;
using cs_lms.Model;

namespace cs_lms.repository;

using System.ComponentModel.DataAnnotations;

public class LibraryRepository
{
    [Required]
    private List<Book> Books { get; set; } = [];
    
    [Required]
    private List<Rent> Rents { get; set; } = [];
    
    [Required]
    private List<User> Users { get; set; } = [];

    private List<T> LoadModel<T>(string filePath)
    {
        try
        {
            var json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());

            var data = JsonSerializer.Deserialize<List<T>>(json, options);
            return data ?? [];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data from '{filePath}': {ex.Message}");
            return [];
        }
    }

    private void SaveModels<T>(List<T> models, string filePath)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        options.Converters.Add(new JsonStringEnumConverter());

        var updatedJson = JsonSerializer.Serialize(models, options);
        File.WriteAllText(filePath, updatedJson);
    }

    public void LoadUsers()
    {
        var userData = LoadModel<UserJsonModel>(FilePaths.UsersDb);

        foreach (var user in userData)
        {
            if (user.Type == "Librarian")
                Users.Add(new Librarian(user.Name, user.BirthDate, user.Email, user.Password));
            else if (user.Type == "Reader")
                Users.Add(new Reader(user.Name, user.BirthDate, user.Email, user.Password));
        }
    }

    public void LoadBooks()
    {
        var bookData = LoadModel<Book>(FilePaths.BooksDb);

        foreach (var book in bookData)
        {
            Books.Add(new Book(book.Title, book.Description, book.Author, book.Genre, book.Blurb, book.IsAvailable));
        }
    }

    public void LoadRents()
    {
        var rentData = LoadModel<Rent>(FilePaths.RentsDb);

        foreach (var rent in rentData)
        {
            Rents.Add(new Rent(rent.Reader, rent.Book, rent.ExpectedReturnDate));
        }
    }

    
    public User? GetUserByEmail(string email)
    {
        return Users.Find(r => r.Email == email);
    }

    public bool ContainsUser(string email)
    {
        return Users.Find(r => r.Email == email) != null;
    }

    public void SaveUser(User user)
    {
        Users.Add(user);
        List<UserJsonModel> models = Users
            .Select(u => new UserJsonModel(u))
            .ToList();

        SaveModels(models, FilePaths.UsersDb);
    }

}