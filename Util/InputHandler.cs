using System.Globalization;

namespace cs_lms.Util;

public static class InputHandler
{
    private static string GetValidInput(string message, Func<string?, bool> isValid)
    {
        string? input;
        while (true)
        {
            Console.Write(message);
            input = Console.ReadLine();
            if (isValid(input))
            {
                break;
            }
            Console.WriteLine("Invalid input!\n");
        }
        return input!;
    }

    public static string GetNonNull(string message) =>
        GetValidInput(message, input => input is not null);

    public static string GetNonEmpty(string message) =>
        GetValidInput(message, input => !string.IsNullOrWhiteSpace(input));
    
    public static string GetValidDate(string message) =>
        GetValidInput(message, input => 
            DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _));


}