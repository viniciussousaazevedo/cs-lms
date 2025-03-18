using cs_lms.Enum;

namespace cs_lms.Model;

using System.ComponentModel.DataAnnotations;

public class Book(string title, string description, string author, Genre genre, string blurb, bool isAvailable)
{
    [Required]
    public string Title { get; set; } = title;
    
    [Required]
    public string Description { get; set; } =  description;
    
    [Required]
    public string Author { get; set; } = author;
    
    [Required]
    public Genre Genre { get; set; } =  genre;
    
    [Required]
    public string Blurb { get; set; } =  blurb;
    
    [Required]
    public bool IsAvailable { get; set; } = isAvailable;

    [Required] public List<Score> Scores { get; set; } = [];
}