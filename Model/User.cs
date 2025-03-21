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

    // Abstract method for role-specific details
    protected abstract string GetRole();
    
    public override string ToString()
    {
        return $"{GetRole()}: {Name}, Birthday: {Birthday:yyyy-MM-dd}, Email: {Email}";
    }
}

public class UserJsonModel
{
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserJsonModel()
    {
        Name = string.Empty;
        Type = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }
    public UserJsonModel(User user)
    {
        Name = user.Name;
        BirthDate = user.Birthday;
        Email = user.Email;
        Password = user.Password;
        Type = user is Librarian ? "Librarian" : "Reader";
    }

}
