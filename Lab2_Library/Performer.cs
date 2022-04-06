using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFor2ndLab
{
    public class Performer : ICloneable, IComparable<Performer>
    {
        private string name;
        private string surname;
        private DateTime birthDate;

        public string Name
        {
            get => name; 
            private set
            {
                name = value;
            }
        }
        public string Surname
        {
            get => surname; 
            private set
            {
                surname = value;
            }
        }
        public DateTime BirthDate
        {
            get => birthDate; 
            private set
            {
                birthDate = value;
            }
        }

        public Performer(string name, string surname, DateTime birthDate)
        {
            this.name = name;
            this.surname = surname;
            this.birthDate = birthDate;
        }

        public object Clone() => new Performer(Name, Surname, BirthDate);

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
            return $"Full name: {Name} {Surname}; \nBirth date: {BirthDate};";
        }
    }
}
