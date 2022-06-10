using LibraryFor2ndLab.Models;

namespace LibraryFor2ndLab.DTO
{
    public class UserDTO
    {
        public long Id;
        public string Username;
        public readonly string Password;
        public readonly string Email;
        public readonly string Phone;
        public Role Role;

        public UserDTO() 
        { }

        public UserDTO(long id, string username, string email, string phone, string password, Role role)
        {
            Id = id;
            Username = username;
            Email = email;
            Phone = phone;
            Password = password;
            Role = role;
        }


    }
}
