namespace cs_lms.Constants;

public class FilePaths
{
    public static readonly string Root = Directory.GetCurrentDirectory();
    public static readonly string Database = Path.Combine(Root, "Database");
    public static readonly string UsersDb = Path.Combine(Database, "Users.json");
    public static readonly string BooksDb = Path.Combine(Database, "Books.json");
    public static readonly string RentsDb = Path.Combine(Database, "Rents.json");
}