using LibraryFor2ndLab.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryFor2ndLab.DTO
{
    public class Customer : Entity, ICloneable, IComparable<Customer>
    {
        [Required]
        private Service _service;

        [Required]
        [DataType(DataType.Text)]
        private string _adress;

        [Required]
        private User _user;

        public Service Service
        {
            get => _service;
            private set { _service = value; }
        }
        public string Adress
        {
            get => _adress;
            private set => _adress = value;
        }
        public User User
        {
            get => _user;
            private set => _user = value;
        }

        public Customer(Service service, string adress, User user) : base()
        {
            _service = service;
            _adress = adress;
            _user = user;
            if (_user.Role == Role.None)
            {
                _user.Role = Role.Customer;
            }
            else
            {
                throw new ArgumentException("You can`t use this alredy taken");
            }
        }

        public Customer(long id, Service service, string adress, User user) : base(id)
        {
            _service = service;
            _adress = adress;
            _user = user;
        }

        public object Clone() => new Customer(Id, Service, Adress, User);

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
            return _service == customer.Service && _adress == customer.Adress;
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
            return $"Id: {Id}; Service: {Service}; Adress: {Adress}; ";
        }
    }
}
