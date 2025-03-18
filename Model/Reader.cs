namespace cs_lms.Model;

using System;
using System.ComponentModel.DataAnnotations;
using cs_lms.Enum;

public class Reader(string name, DateTime birthday, string email, string password)
    : User(name, birthday, email, password)
{
    [Required] private List<Book> BookHistory { get; set; } = [];
    public List<Genre> Taste { get; set; } = [];
    protected override string GetRole() => "Reader";
}