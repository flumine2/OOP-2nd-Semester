using LibraryFor2ndLab.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Lab_2.Repository
{
    class CustomerRepository : IRepository<Customer>
    {
        private readonly List<Customer> _base;
        private readonly UserRepository _userRepository;

        public CustomerRepository(UserRepository userRepository)
        {
            _userRepository = userRepository;
            _base = new List<Customer>();
        }

        public void Add(Customer entity)
        {
            _userRepository.Add(entity.User);
            _base.Add(entity);
        }

        public Customer GetById(long id)
        {
            Customer[] customers = _base.Where(x => x.Id == id).ToArray();
            if (customers.Length > 0)
            {
                return customers[0];
            }
            else
            {
                return null;
            }
        }
    }
}
