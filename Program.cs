using cs_lms.controller;
using cs_lms.Model;
using cs_lms.interfaces;
using cs_lms.Util;

namespace cs_lms;

public static class Program
{
    private static LibraryController Controller { get; } = new LibraryController();
    private static User? _user;
    public static void Main(string[] args)
    {
        Login();
        switch (_user)
        {
            case Librarian librarian:
                LibrarianMenu.ShowLibrarianMenu(librarian, Controller);
                break;
            case Reader reader:
                ReaderMenu.ShowReaderMenu(reader, Controller);
                break;
        }
    }

    private static void Login()
    {
        while (true)
        {
            Console.WriteLine("Hello! Welcome to the Library Management System :)");
            Console.WriteLine("Please, log in to use the system");
            var email = InputHandler.GetNonEmpty("email: ");
            var password = InputHandler.GetNonEmpty("password: ");
            _user = Controller.LogIn(email, password);
            if (_user is not null)
            {
                Console.WriteLine("Success!\n");
                break;
            }
            Console.WriteLine("Incorrect credentials!\n");
        }
    }

    

    
}