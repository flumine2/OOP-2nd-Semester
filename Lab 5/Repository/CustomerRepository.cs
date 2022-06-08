using LibraryFor2ndLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.Repository
{
    class CustomerRepository : IRepository<Customer>
    {
        public static List<Customer> _base;



        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
