using cs_lms.Model;

namespace cs_lms.repository;

using System.ComponentModel.DataAnnotations;

public class LibraryRepository
{
    [Required]
    public List<Book> Books { get; set; }
    
    [Required]
    public List<BookRent> Rents { get; set; }
    
    [Required]
    public List<Librarian> Librarians { get; set; }
    
    [Required]
    public List<Reader> Readers { get; set; }
}