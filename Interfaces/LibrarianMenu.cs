
using System.Globalization;
using cs_lms.controller;
using cs_lms.Model;
using cs_lms.Util;

namespace cs_lms.interfaces;

public static class LibrarianMenu
{
    private static Librarian? _librarian;
    private static LibraryController? _libraryController;
    public static void ShowLibrarianMenu(Librarian librarian, LibraryController libraryController)
    {
        _librarian = librarian;
        _libraryController = libraryController;
        while (true)
        {
            Console.WriteLine("[LIBRARY MANAGEMENT SYSTEM - LIBRARIAN PROFILE]");
            Console.WriteLine($"Hello, {_librarian.Name}! What would you like to do?\n");

            Console.WriteLine("1 - Create Reader");
            Console.WriteLine("2 - Exit\n");

            var option = Convert.ToInt32(InputHandler.GetNonEmpty("Option: "));
            Console.Write("\n");
            
            switch (option)
            {
                case 1:
                    CreateReader();
                    break;
                case 2:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    private static void CreateReader()
    {
        var name = InputHandler.GetNonEmpty("Reader Name: ");
        var email = InputHandler.GetNonEmpty("Reader Email: ");
        var strBirthDate = InputHandler.GetValidDate("Reader Birth Date: ");
        DateTime.TryParseExact(strBirthDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
            out DateTime birthDate);
        
        
        Console.WriteLine(_libraryController.CreateReader(name, birthDate, email));
    }

    private static void Exit()
    {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }
}