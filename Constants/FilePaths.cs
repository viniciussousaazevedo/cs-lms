namespace cs_lms.Constants;

public class FilePaths
{
    private static readonly string Root = Directory.GetCurrentDirectory();
    private static readonly string Database = Path.Combine(Root, "Database");
    public static readonly string LibrariansDb = Path.Combine(Database, "Librarians.json");
    public static readonly string ReadersDb = Path.Combine(Database, "Readers.json");
    public static readonly string BooksDb = Path.Combine(Database, "Books.json");
    public static readonly string RentsDb = Path.Combine(Database, "Rents.json");
}