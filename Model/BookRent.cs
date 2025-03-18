namespace cs_lms.Model;

using System;
using System.ComponentModel.DataAnnotations;

public class BookRent
{
    [Required]
    public Reader Reader { get; set; }
    
    [Required]
    public Book Book { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime ExpectedReturnDate { get; set; } 
    
    [DataType(DataType.Date)]
    public DateTime? ActualReturnDate { get; set; }
}