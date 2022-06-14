using Lab6.Data;
using LibraryFor2ndLab.Converters;
using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab6.Data.Repositories.APIs
{
    class OrderRepository : IRepository<Order>
    {
        private readonly DataBase _base;

        public OrderRepository(DataBase dataBase)
        {
            _base = dataBase;
            Deserialise();
        }

        public void Add(Order entity)
        {
            if (!_base.Orders.Select(x => x.Id).Contains(entity.Id))
            {
                _base.Orders.Add(entity);
            }
        }

        public Order GetById(long id)
        {
            return _base.Orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> FindAllByCustomerId(long id)
        {
            return _base.Orders.Where(x => x.Customer.Id == id).ToList();
        }

        public List<Order> FindAllByPerformerId(long id)
        {
            return _base.Orders.Where(x => x.Performer.Id == id).ToList();
        }

        public List<Order> FindAllByService(Service service)
        {
            return _base.Orders.Where(x => x.Customer.Service == service).ToList();
        }

        public void Serialise()
        {
            string jsonString = JsonConvert.SerializeObject(_base.Orders.Select(x => OrderConverter.ConvertToDTO(x)).ToList());

            File.WriteAllText("Orders.json", jsonString);
        }

        public void Deserialise()
        {
            if (File.Exists("Orders.json"))
            {
                List<OrderDTO> deserialisedOrder = JsonConvert.DeserializeObject<List<OrderDTO>>(File.ReadAllText("Orders.json"));

                if (deserialisedOrder is null) return;

                foreach (Order order in deserialisedOrder.Select(x => OrderConverter.ConvertToModel(x)))
                {
                    Add(order);
                }
            }
            else
            {
                using (var sw = File.CreateText("Orders.json"))
                {
                    sw.WriteLine("[]");
                }
            }
        }
    }
}
