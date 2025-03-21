namespace cs_lms.Model;

using System;
using System.ComponentModel.DataAnnotations;

public class Librarian(string name, DateTime birthday, string email, string password) 
    : User(name, birthday, email, password)
{
    public override string GetRole() => "Librarian";
}
