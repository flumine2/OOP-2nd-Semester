using LibraryFor2ndLab.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Lab_2.Repository
{
    class ServiceDeskRepository : IRepository<ServiceDesk>
    {
        private readonly List<ServiceDesk> _base;
        private readonly OrderRepository _orderRepository;

        public ServiceDeskRepository(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _base = new List<ServiceDesk>();
        }

        public void Add(ServiceDesk entity)
        {
            foreach (Order order in entity.OrdersList)
            {
                _orderRepository.Add(order);
            }
            _base.Add(entity);
        }

        public ServiceDesk GetById(long id)
        {
            ServiceDesk[] serviceDesks = _base.Where(x => x.Id == id).ToArray();
            if (serviceDesks.Length > 0)
            {
                return serviceDesks[0];
            }
            else
            {
                return null;
            }
        }
    }
}
