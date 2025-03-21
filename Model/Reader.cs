namespace cs_lms.Model;

using System;
using System.ComponentModel.DataAnnotations;
using cs_lms.Enum;

public class Reader(string name, DateTime birthday, string email, string password, List<Genre> taste)
    : User(name, birthday, email, password)
{
    public List<Genre> Taste { get; set; } = taste;
    public override string GetRole() => "Reader";
}