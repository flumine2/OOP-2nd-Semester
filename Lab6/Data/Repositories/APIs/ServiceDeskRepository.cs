using LibraryFor2ndLab.Converters;
using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab6.Data.Repositories.APIs
{
    class ServiceDeskRepository : IRepository<ServiceDesk>
    {
        private readonly DataBase _base;

        public ServiceDeskRepository(DataBase dataBase)
        {
            _base = dataBase;
            Deserialise();
        }

        public void Add(ServiceDesk entity)
        {
            if (!_base.ServiceDesks.Select(x => x.Id).Contains(entity.Id))
            {
                _base.ServiceDesks.Add(entity);
            }
        }

        public void Remove(ServiceDesk entity)
        {
            if (_base.ServiceDesks.Select(x => x.Id).Contains(entity.Id))
            {
                _base.ServiceDesks.Remove(entity);
            }
        }

        public ServiceDesk GetById(long id)
        {
            return _base.ServiceDesks.FirstOrDefault(x => x.Id == id);
        }

        public List<ServiceDesk> FindAllByCustomerId(long id)
        {
            return _base.ServiceDesks
                .Where(x => x.OrdersList
                    .Select(y => y.Customer.Id)
                    .Contains(id))
                .ToList();
        }

        public List<ServiceDesk> FindAllByPerformerId(long id)
        {
            return _base.ServiceDesks
                .Where(x => x.OrdersList
                    .Select(y => y.Performer.Id)
                    .Contains(id))
                .ToList();
        }

        public List<ServiceDesk> FindAllByOrderId(long id)
        {
            return _base.ServiceDesks
                .Where(x => x.OrdersList.Select(y => y.Id).Contains(id))
                .ToList();
        }

        public List<ServiceDesk> FindAllByService(Service service)
        {
            return _base.ServiceDesks
                .Where(x => x.OrdersList
                    .Select(y => y.Customer.Service)
                    .Contains(service))
                .ToList();
        }

        public void Serialise()
        {
            string jsonString = JsonConvert.SerializeObject(_base.ServiceDesks.Select(x => ServiceDeskConverter.ConvertToDTO(x)).ToList());

            File.WriteAllText("SeviceDesks.json", jsonString);
        }

        public void Deserialise()
        {
            if (File.Exists("SeviceDesks.json"))
            {
                List<ServiceDeskDTO> deserialisedDesks = JsonConvert.DeserializeObject<List<ServiceDeskDTO>>(File.ReadAllText("SeviceDesks.json"));

                if (deserialisedDesks is null) return;

                foreach (ServiceDesk serviceDesk in deserialisedDesks.Select(x => ServiceDeskConverter.ConvertToModel(x)))
                {
                    Add(serviceDesk);
                }
            }
            else
            {
                using (var sw = File.CreateText("SeviceDesks.json"))
                {
                    sw.WriteLine("[]");
                }
            }
        }
    }
}
