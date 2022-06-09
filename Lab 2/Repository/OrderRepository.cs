using LibraryFor2ndLab.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Lab_2.Repository
{
    class OrderRepository : IRepository<Order>
    {
        private readonly List<Order> _base;
        private readonly PerformerRepository _performerRepository;
        private readonly CustomerRepository _customerRepository;

        public OrderRepository(PerformerRepository performerRepository, CustomerRepository customerRepository)
        {
            _performerRepository = performerRepository;
            _customerRepository = customerRepository;
            _base = new List<Order>();
        }

        public void Add(Order entity)
        {
            _performerRepository.Add(entity.Performer);
            _customerRepository.Add(entity.Customer);
            _base.Add(entity);
        }

        public Order GetById(long id)
        {
            Order[] orders = _base.Where(x => x.Id == id).ToArray();
            if (orders.Length > 0)
            {
                return orders[0];
            }
            else
            {
                return null;
            }
        }
    }
}
