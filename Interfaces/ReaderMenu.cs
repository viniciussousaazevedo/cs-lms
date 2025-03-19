using cs_lms.controller;
using cs_lms.Model;

namespace cs_lms.interfaces;

public static class ReaderMenu
{
    private static Reader? _reader;
    private static LibraryController? _libraryController;
    public static void ShowReaderMenu(Reader reader,  LibraryController libraryController)
    {
        _reader = reader;
        _libraryController = new LibraryController();
        while (true)
        {
            Console.WriteLine("[LIBRARY MANAGEMENT SYSTEM - READER PROFILE]");
            Console.WriteLine($"Hello, {_reader.Name}! What would you like to do?\n");

            Console.WriteLine("TODO");
        }
    }
}