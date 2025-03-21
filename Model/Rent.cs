namespace cs_lms.Model;

using System;
using System.ComponentModel.DataAnnotations;

public class Rent(Reader reader, Book book, DateTime expectedReturnDate)
{
    [Required] public Reader Reader { get; set; } = reader;
    
    [Required]
    public Book Book { get; set; } = book;

    [Required] [DataType(DataType.Date)] public DateTime ExpectedReturnDate { get; set; } = expectedReturnDate;

    [DataType(DataType.Date)] public DateTime? ActualReturnDate { get; set; } = null;
}