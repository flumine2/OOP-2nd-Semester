using LibraryFor2ndLab.Converters;
using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_2.Repository
{
    class ServiceDeskRepository : IRepository<ServiceDesk>
    {
        private readonly Dictionary<long, ServiceDesk> _base;

        public ServiceDeskRepository()
        {
            _base = new Dictionary<long, ServiceDesk>();
        }

        public int Count
        {
            get => _base.Count;
        }

        public void Add(ServiceDesk entity)
        {
            if (!_base.ContainsKey(entity.Id))
            {
                _base.Add(entity.Id, entity);
            }
        }

        public ServiceDesk GetById(long id)
        {
            ServiceDesk[] serviceDesks = _base.Where(x => x.Key == id).Select(x => x.Value).ToArray();
            if (serviceDesks.Length > 0)
            {
                return serviceDesks[0];
            }
            else
            {
                return null;
            }
        }

        public List<ServiceDesk> FindAllByCustomerId(long id)
        {
            return _base
                .Select(x => x.Value)
                .Where(x => x.OrdersList
                    .Select(x => x.Customer.Id)
                    .Contains(id))
                .ToList();
        }

        public List<ServiceDesk> FindAllByPerformerId(long id)
        {
            return _base
                .Select(x => x.Value)
                .Where(x => x.OrdersList
                    .Select(x => x.Performer.Id)
                    .Contains(id))
                .ToList();
        }

        public List<ServiceDesk> FindAllByUserId(long id)
        {
            return _base
                .Select(x => x.Value)
                .Where(x => x.OrdersList.Select(x => x.Performer.User.Id).Contains(id) || x.OrdersList.Select(x => x.Customer.User.Id).Contains(id))
                .ToList();
        }

        public List<ServiceDesk> FindAllByOrderId(long id)
        {
            return _base
                .Select(x => x.Value)
                .Where(x => x.OrdersList.Select(x => x.Id).Contains(id))
                .ToList();
        }

        public List<ServiceDesk> FindAllByService(Service service)
        {
            return _base
                .Select(x => x.Value)
                .Where(x => x.OrdersList
                    .Select(x => x.Customer.Service)
                    .Contains(service))
                .ToList();
        }

        public void Serialise()
        {
            string jsonString = JsonConvert.SerializeObject(_base.Select(x => x.Value).Select(x => ServiceDeskConverter.ConvertToDTO(x)).ToList());

            File.WriteAllText("SeviceDesks.json", jsonString);
        }

        public void Deserialise()
        {
            List<ServiceDeskDTO> deserialisedDesks = JsonConvert.DeserializeObject<List<ServiceDeskDTO>>(File.ReadAllText("SeviceDesks.json"));

            foreach (ServiceDesk serviceDesk in deserialisedDesks.Select(x => ServiceDeskConverter.ConvertToModel(x)))
            {
                Add(serviceDesk);
            }
        }
    }
}
