using LibraryFor2ndLab.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryFor2ndLab.Models.Person
{
    public class Performer : Entity, ICloneable, IComparable<Performer>
    {
        public Performer(string name, string surname, DateTime birthDate, User user) : base()
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            User = user;
            if (User.Role == Role.None)
            {
                User.Role = Role.Performer;
            }
            else
            {
                throw new ArgumentException("You can`t use this User like a Performer - it is Customer already");
            }
        }

        public Performer(long id, string name, string surname, DateTime birthDate, User user) : base(id)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            User = user;
        }

        [Required]
        [StringLength(30)]
        [DataType(DataType.Text)]
        public string Name { get; private set; }

        [Required]
        [StringLength(30)]
        [DataType(DataType.Text)]
        public string Surname { get; private set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; private set; }

        [Required]
        public User User { get; private set; }

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
            return $"Id: {Id}; Full name: {Name} {Surname}; \nBirth date: {BirthDate}; \n User: " + User.ToString();
        }
    }
}
