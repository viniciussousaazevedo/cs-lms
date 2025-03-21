using System.Text.Json;
using System.Text.Json.Serialization;
using cs_lms.Constants;
using cs_lms.DTO;
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
        var librariansData = LoadModel<LibrarianDto>(FilePaths.LibrariansDb);
        librariansData.ForEach(dto => Users.Add(new Librarian(dto.Name, dto.Birthday, dto.Email, dto.Password)));
        var readersData = LoadModel<ReaderDto>(FilePaths.ReadersDb);
        readersData.ForEach(dto => Users.Add(new Reader(dto.Name, dto.Birthday, dto.Email, dto.Password, dto.Taste)));
    }

    public void LoadBooks()
    {
        var bookData = LoadModel<Book>(FilePaths.BooksDb);
        bookData.ForEach(dto => Books.Add(new Book(dto.Title, dto.Description, dto.Author, dto.Genre, dto.Blurb, dto.IsAvailable)));
    }

    public void LoadRents()
    {
        var rentData = LoadModel<Rent>(FilePaths.RentsDb);
        rentData.ForEach(dto => Rents.Add(new Rent(dto.Reader, dto.Book, dto.ExpectedReturnDate)));
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
        var librarianDtos = Users
            .OfType<Librarian>()
            .Select(l => new LibrarianDto(l))
            .ToList();
        var readersDtos = Users
            .OfType<Reader>()
            .Select(r => new ReaderDto(r))
            .ToList();


        SaveModels(librarianDtos, FilePaths.LibrariansDb);
        SaveModels(readersDtos, FilePaths.ReadersDb);
    }

}