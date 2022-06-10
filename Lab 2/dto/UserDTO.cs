using LibraryFor2ndLab.Models;

namespace Lab_2.DTO
{
    class UserDTO
    {
        public long Id;
        public string Username;
        public readonly string Password;
        public readonly string Email;
        public readonly string Phone;
        public Role Role;

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
