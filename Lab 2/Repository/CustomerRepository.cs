using LibraryFor2ndLab.Converters;
using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models;
using LibraryFor2ndLab.Models.Person;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_2.Repository
{
    class CustomerRepository : IRepository<Customer>
    {
        private readonly Dictionary<long, Customer> _base;

        public CustomerRepository()
        {
            _base = new Dictionary<long, Customer>();
        }

        public int Count
        {
            get => _base.Count;
        }

        public void Add(Customer entity)
        {
            if (!_base.ContainsKey(entity.Id))
            {
                _base.Add(entity.Id, entity);
            }
        }

        public Customer GetById(long id)
        {
            Customer[] customers = _base.Where(x => x.Key == id).Select(x => x.Value).ToArray();
            if (customers.Length > 0)
            {
                return customers[0];
            }
            else
            {
                return null;
            }
        }

        public Customer FindByUserId(long id)
        {
            return _base.Select(x => x.Value).Where(x => x.User.Id == id).First(); 
        }

        public List<Customer> FindAllByService(Service service)
        {
            return _base.Select(x => x.Value).Where(x => x.Service == service).ToList();
        }

        public void Serialise()
        {
            string jsonString = JsonConvert
                .SerializeObject(_base
                .Select(x => x.Value)
                .Select(x => CustomerConverter.ConvertToDTO(x))
                .ToList());

            File.WriteAllText("Customers.json", jsonString);
        }

        public void Deserialise()
        {
            List<CustomerDTO> deserialisedCustomers = JsonConvert.DeserializeObject<List<CustomerDTO>>(File.ReadAllText("Customers.json"));

            foreach (Customer customer in deserialisedCustomers.Select(x => CustomerConverter.ConvertToModel(x)))
            {
                Add(customer);
            }
        }
    }
}
