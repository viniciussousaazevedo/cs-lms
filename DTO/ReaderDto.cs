using cs_lms.Enum;
using cs_lms.Model;

namespace cs_lms.DTO;

public class ReaderDto(Reader reader) : UserDto(reader)
{
    public List<Genre> Taste { get; set; } = reader.Taste;
}