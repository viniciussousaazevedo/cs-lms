namespace cs_lms.Model;

using System;
using System.ComponentModel.DataAnnotations;
using cs_lms.Enum;

public class Reader(string name, DateTime birthday, string email, string password, List<Book> bookHistory, List<Genre> taste)
    : User(name, birthday, email, password)
{
    [Required] private List<Book> BookHistory { get; set; } =  bookHistory;
    public List<Genre> Taste { get; set; }= taste;
    protected override string GetRole() => "Reader";
}