namespace cs_lms.Model;

using System.ComponentModel.DataAnnotations;

public class Score
{
    [Required]
    public Reader RatedBy { get; set; }
    
    [Required]
    public int Stars { get; set; }
    
    public string Comment { get; set; }
}