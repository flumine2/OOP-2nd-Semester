using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFor2ndLab
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        private Service service;
        private string adress;

        public Service Service
        {
            get => service;
            private set { service = value; }
        }
        public string Adress
        {
            get => adress;
            private set { adress = value; }
        }

        public Customer(Service service, string adress)
        {
            this.service = service;
            this.adress = adress;
        }

        public object Clone() => new Customer(Service, Adress);

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
            return service == customer.Service && adress == customer.Adress;
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
            return $"Service: {Service}; Adress: {Adress}; ";
        }
    }
}
