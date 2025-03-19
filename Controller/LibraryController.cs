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

    public string CreateReader(string name, string password, DateTime birthDate, string email)
    {
        return "so far, so good :)";
    }
}