using cs_lms.Enum;
using cs_lms.Model;

namespace cs_lms.repository;

using System.ComponentModel.DataAnnotations;

public class LibraryRepository
{
    [Required] public List<Book> Books { get; set; } = [];
    
    [Required]
    public List<BookRent> Rents { get; set; } = [];
    
    [Required]
    public List<Librarian> Librarians { get; set; } = [];
    
    [Required]
    public List<Reader> Readers { get; set; } = [];

    public void Populate()
    {
        var defaultLibrarian = new Librarian(
            "Vinícius Azevedo",
            new DateTime(2002, 5, 21),
            "sousa0240@gmail.com",
            "123"
        );
        Librarians.Add(defaultLibrarian);
        
        var r1 = new Reader(
            "Alice Johnson",
            new DateTime(2000, 5, 15),
            "alice.johnson@example.com",
            "123"
        );
        
        var r2 = new Reader(
            "Robert Smith",
            new DateTime(1985, 10, 3),
            "robert.smith@example.com",
            "123"
        );
        
        var r3 = new Reader(
            "Margaret Taylor",
            new DateTime(1960, 8, 22),
            "margaret.taylor@example.com",
            "123"
        );
        Readers.AddRange(r1, r2, r3);
        
        var b1 = new Book(
            "The Catcher in the Rye",
            "A classic novel about teenage rebellion and identity.",
            "J.D. Salinger",
            Genre.Fiction,
            "Holden Coalfield narrates his experiences in New York City.",
            true
        );
        
        var b2 = new Book(
            "A Brief History of Time",
            "An exploration of cosmology and the nature of the universe.",
            "Stephen Hawking",
            Genre.Science,
            "A deep dive into black holes, time travel, and the Big Bang.",
            true
        );
        
        var b3 = new Book(
            "Gone Girl",
            "A psychological thriller about a missing wife.",
            "Gillian Flynn",
            Genre.Mystery,
            "Nick Dunne becomes the prime suspect in his wife's disappearance.",
            false
        );

        var b4 = new Book(
            "The Hobbit",
            "A fantasy adventure following Bilbo Baggins on a quest.",
            "J.R.R. Tolkien",
            Genre.Fantasy,
            "Bilbo, a hobbit, embarks on an adventure to reclaim a lost treasure.",
            true
        );
        
        var b5 = new Book(
            "Steve Jobs",
            "The biography of Apple's co-founder, Steve Jobs.",
            "Walter Isaacson",
            Genre.Biography,
            "A comprehensive look into Steve Jobs' life and career.",
            true
        );
        Books.AddRange(b1, b2, b3, b4, b5);
        
    }
}