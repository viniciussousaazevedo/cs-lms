namespace cs_lms.Model;

using System;
using System.ComponentModel.DataAnnotations;

public abstract class User(string name, DateTime birthday, string email, string password)
{
    [Required]
    public string Name { get; set; } = name;

    [Required] [DataType(DataType.Date)]
    public DateTime Birthday { get; set; } = birthday;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = email;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = password;
    
    public abstract string GetRole();
    
    public override string ToString()
    {
        return $"{GetRole()}: {Name}, Birthday: {Birthday:yyyy-MM-dd}, Email: {Email}";
    }
}