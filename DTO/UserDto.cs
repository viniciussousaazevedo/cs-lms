using cs_lms.Model;

namespace cs_lms.DTO;

public abstract class UserDto(User user)
{
    public string Name { get; set; } =  user.Name;
    public string Type { get; set; } = user.GetRole();
    public DateTime Birthday { get; set; } =  user.Birthday;
    public string Email { get; set; }  =  user.Email;
    public string Password { get; set; }  =  user.Password;
}
