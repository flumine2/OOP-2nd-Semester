using LibraryFor2ndLab.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryFor2ndLab.DTO
{
    public class Performer : Entity, ICloneable, IComparable<Performer>
    {
        [Required]
        [StringLength(30)]
        [DataType(DataType.Text)]
        private string _name;

        [Required]
        [StringLength(30)]
        [DataType(DataType.Text)]
        private string _surname;

        [Required]
        [DataType(DataType.Date)]
        private DateTime _birthDate;

        [Required]
        private User _user;

        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
            }
        }
        public string Surname
        {
            get => _surname;
            private set
            {
                _surname = value;
            }
        }
        public DateTime BirthDate
        {
            get => _birthDate;
            private set
            {
                _birthDate = value;
            }
        }
        public User User
        {
            get => _user;
            private set
            {
                _user = value;
            }
        }

        public Performer(string name, string surname, DateTime birthDate, User user) : base()
        {
            _name = name;
            _surname = surname;
            _birthDate = birthDate;
            _user = user;
            if (_user.Role == Role.None)
            {
                _user.Role = Role.Performer;
            }
            else
            {
                throw new ArgumentException("You can`t use this User like a Performer - it is Customer already");
            }
        }

        public Performer(long id, string name, string surname, DateTime birthDate, User user) : base(id)
        {
            _name = name;
            _surname = surname;
            _birthDate = birthDate;
            _user = user;
        }

        public object Clone() => new Performer(Id, Name, Surname, BirthDate, User);

        public int CompareTo(Performer other)
        {
            if (other is null)
                throw new ArgumentException("Invalid parameter value");

            if (BirthDate.CompareTo(other.BirthDate) == 0)
            {
                if (Surname.CompareTo(other.Surname) == 0)
                {
                    return Name.CompareTo(other.Name);
                }
                else
                {
                    return Surname.CompareTo(other.Surname);
                }
            }
            else
                return BirthDate.CompareTo(other.BirthDate);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Performer performer))
            {
                return false;
            }
            return Name == performer.Name && Surname == performer.Surname && BirthDate == performer.BirthDate;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Surname.GetHashCode() + BirthDate.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id: {Id}; Full name: {Name} {Surname}; \nBirth date: {BirthDate};";
        }
    }
}
