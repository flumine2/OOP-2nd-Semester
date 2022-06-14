using LibraryFor2ndLab.Converters;
using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models;
using LibraryFor2ndLab.Models.Person;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab6.Data.Repositories.APIs
{
    class CustomerRepository : IRepository<Customer>
    {
        private readonly DataBase _base;

        public CustomerRepository(DataBase dataBase)
        {
            _base = dataBase;
            Deserialise();
        }

        public void Add(Customer entity)
        {
            if (!_base.Customers.Select(x => x.Id).Contains(entity.Id))
            {
                _base.Customers.Add(entity);
            }
        }

        public Customer GetById(long id)
        {
            return _base.Customers.FirstOrDefault(x => x.Id == id);
        }

        public List<Customer> FindAllByService(Service service)
        {
            return _base.Customers.Where(x => x.Service == service).ToList();
        }

        public void Serialise()
        {
            string jsonString = JsonConvert.SerializeObject(_base.Customers
                .Select(x => CustomerConverter.ConvertToDTO(x))
                .ToList());

            File.WriteAllText("Customers.json", jsonString);
        }

        public void Deserialise()
        {
            if (File.Exists("Customers.json"))
            {
                List<CustomerDTO> deserialisedCustomers = JsonConvert.DeserializeObject<List<CustomerDTO>>(File.ReadAllText("Customers.json"));

                if (deserialisedCustomers is null) return;

                foreach (Customer customer in deserialisedCustomers.Select(x => CustomerConverter.ConvertToModel(x)))
                {
                    Add(customer);
                }
            }
            else
            {
                using (var sw = File.CreateText("Customers.json"))
                {
                    sw.WriteLine("[]");
                }
            }
        }
    }
}
