using LibraryFor2ndLab.Converters;
using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_2.Repository
{
    class OrderRepository : IRepository<Order>
    {
        private readonly Dictionary<long, Order> _base;

        public OrderRepository()
        {
            _base = new Dictionary<long, Order>();
        }

        public int Count
        {
            get => _base.Count;
        }

        public void Add(Order entity)
        {
            if (!_base.ContainsKey(entity.Id))
            {
                _base.Add(entity.Id, entity);
            }
        }

        public Order GetById(long id)
        {
            Order[] orders = _base.Where(x => x.Key == id).Select(x => x.Value).ToArray();
            if (orders.Length > 0)
            {
                return orders[0];
            }
            else
            {
                return null;
            }
        }

        public List<Order> FindAllByCustomerId(long id)
        {
            return _base.Select(x => x.Value).Where(x => x.Customer.Id == id).ToList();
        }

        public List<Order> FindAllByPerformerId(long id)
        {
            return _base.Select(x => x.Value).Where(x => x.Performer.Id == id).ToList();
        }

        public List<Order> FindAllByUserId(long id)
        {
            return _base.Select(x => x.Value).Where(x => x.Customer.User.Id == id || x.Performer.User.Id == id).ToList();
        }

        public List<Order> FindAllByService(Service service)
        {
            return _base.Select(x => x.Value).Where(x => x.Customer.Service == service).ToList();
        }

        public void Serialise()
        {
            string jsonString = JsonConvert.SerializeObject(_base.Select(x => x.Value).Select(x => OrderConverter.ConvertToDTO(x)).ToList());

            File.WriteAllText("Orders.json", jsonString);
        }

        public void Deserialise()
        {
            List<OrderDTO> deserialisedOrder = JsonConvert.DeserializeObject<List<OrderDTO>>(File.ReadAllText("Orders.json"));

            foreach (Order order in deserialisedOrder.Select(x => OrderConverter.ConvertToModel(x)))
            {
                Add(order);
            }
        }
    }
}
