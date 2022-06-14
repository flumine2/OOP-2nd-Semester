using LibraryFor2ndLab.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryFor2ndLab.Models.Person
{
    public class Customer : Entity, ICloneable, IComparable<Customer>
    {
        public Customer(Service service, string adress) : base()
        {
            Service = service;
            Adress = adress;
        }

        public Customer(long id, Service service, string adress) : base(id)
        {
            Service = service;
            Adress = adress;
        }

        [Required]
        public Service Service { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Adress { get; set; }

        public object Clone() => new Customer(Id, Service, Adress);

        public int CompareTo(Customer other)
        {
            if (other is null)
                throw new ArgumentException("Invalid parameter value");

            return Adress.CompareTo(other.Adress);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Customer customer))
            {
                return false;
            }
            return Service == customer.Service && Adress == customer.Adress;
        }

        public override int GetHashCode()
        {
            int hash = (int)Service;
            for (int i = 0; i < Adress.Length; i++)
            {
                hash += hash * 13 + Adress[i];
            }
            return hash;
        }

        public override string ToString()
        {
            return $"Id: {Id}; Service: {Service}; Adress: {Adress};";
        }
    }
}
