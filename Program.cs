using System.Runtime.CompilerServices;
using cs_lms.controller;
using cs_lms.Model;

namespace cs_lms;

public class Program
{
    private static LibraryController _controller { get; } = new LibraryController();
    public static void Main(string[] args)
    {
        var user = Login();
    }

    private static User Login()
    {
        User user = null;
        while (true)
        {
            Console.WriteLine("Hello! Welcome to the Library Management System :)");
            Console.WriteLine("Please, log in to use the system");
            Console.Write("email: "); string email = Console.ReadLine();
            Console.Write("password: "); string password = Console.ReadLine();
            user = _controller.LogIn(email, password);
            if (user is not null)
            {
                Console.WriteLine("Success!");
                break;
            }
            Console.WriteLine("Incorrect credentials!\n");
        }

        return user;
    }
}