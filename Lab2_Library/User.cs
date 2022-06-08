using LibraryFor2ndLab.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryFor2ndLab
{
    public class User : Entity, ICloneable, IComparable<User>
    {
        public Role Role;

        [Required]
        [StringLength(30, MinimumLength = 1)]
        private readonly string _username;

        [Required]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        private readonly string _password;

        [Required]
        [RegularExpression(@"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
         ErrorMessage = "Characters are not allowed.")]
        private readonly string _email;

        [Required]
        [RegularExpression(@"(\+38)?0(50|63|67|68|93|95|96|97|98|99)-?\d{3}-?\d{2}-?\d{2}",
         ErrorMessage = "Invalid form of .")]
        private readonly string _phone;

        public string Username
        {
            get => _username; 
        }
        public string Password
        {
            get => _password;
        }
        public string Email
        {
            get => _email;
        }
        public string Phone
        {
            get => _phone;
        }

        public User(string username, string email, string phone, string password) : base()
        {
            _username = username;
            _email = email;
            _phone = phone;
            _password = password;
        }

        public User(long id, string username, string email, string phone, string password, Role role) : base(id)
        {
            _username = username;
            _email = email;
            _phone = phone;
            _password = password;
            Role = role;
        }

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
