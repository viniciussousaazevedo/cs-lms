using cs_lms.Model;
using cs_lms.repository;

namespace cs_lms.controller;

public class LibraryController
{
    private LibraryRepository _repository = new();

    public LibraryController()
    {
        _repository.Populate();
    }

    public User LogIn(string email, string password)
    {
        var user = _repository.GetUserByEmail(email);
        return user is not null && password == user.Password ? user : null;
    }

    public string CreateReader(string name, DateTime birthDate, string email)
    {
        if (_repository.ContainsUser(email))
        {
            return "User already exists!\n";
        }
        
        var reader = new Reader(
            name,
            birthDate,
            email,
            birthDate.ToString("MMddyyyy")
        );
        return "Successfully created Reader!\n";
    }
}