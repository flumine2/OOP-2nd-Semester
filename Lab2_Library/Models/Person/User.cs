using LibraryFor2ndLab.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryFor2ndLab.Models.Person
{
    public class User : Entity, ICloneable, IComparable<User>
    {
        public User(string username, string email, string phone, string password) : base()
        {
            Username = username;
            Email = email;
            Phone = phone;
            Password = password;
            Role = Role.None;
        }

        public User(long id, string username, string email, string phone, string password, Role role) : base(id)
        {
            Username = username;
            Email = email;
            Phone = phone;
            Password = password;
            Role = role;
        }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Username { get; private set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; private set; }

        [Required]
        [RegularExpression(@"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
         ErrorMessage = "Email wrong form it must be like jakenson@email.com.")]
        public string Email { get; private set; }

        [Required]
        [RegularExpression(@"(\+38)?0(50|63|67|68|93|95|96|97|98|99)-?\d{3}-?\d{2}-?\d{2}",
         ErrorMessage = "Invalid form of phone. It must be like (+38)0xx-xxx-xx-xx.")]
        public string Phone { get; private set; }

        [Required]
        public Role Role { get; set; }

        public object Clone() => new User(Username, Email, Phone, Password);

        public int CompareTo(User other)
        {
            if (other is null)
                throw new ArgumentException("Invalid parameter value");

            return Username.CompareTo(other.Username);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is User user))
            {
                return false;
            }
            return Username == user.Username;
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode() + Id.GetHashCode() + Email.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id: {Id}; Username: {Username}; Password: {Password}; Role: {Role}; Email: {Email}; Phone: {Phone};";
        }
    }
}
