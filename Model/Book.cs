using cs_lms.Enum;

namespace cs_lms.Model;

using System.ComponentModel.DataAnnotations;

public class Book
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Author { get; set; }
    
    [Required]
    public Genre Genre { get; set; }
    
    [Required]
    public string Blurb { get; set; }
    
    [Required]
    public bool IsAvailable { get; set; }
    
    [Required]
    public List<Score> Scores { get; set; }
}