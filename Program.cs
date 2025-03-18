using cs_lms.controller;

namespace cs_lms;

public class Program
{
    public static void Main(string[] args)
    {
        var controller = new LibraryController();
        Console.Write(controller);
    }
}