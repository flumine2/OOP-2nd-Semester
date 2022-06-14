using Lab6.Data;
using LibraryFor2ndLab.Converters;
using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models.Person;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab6.Data.Repositories.APIs
{
    class PerformerRepository : IRepository<Performer>
    {
        private readonly DataBase _base;

        public PerformerRepository(DataBase dataBase)
        {
            _base = dataBase;
            Deserialise();
        }

        public void Add(Performer entity)
        {
            if (!_base.Performers.Select(x => x.Id).Contains(entity.Id))
            {
                _base.Performers.Add(entity);
            }
        }

        public Performer GetById(long id)
        {
            return _base.Performers.FirstOrDefault(x => x.Id == id);
        }

        public void Serialise()
        {
            string jsonString = JsonConvert.SerializeObject(_base.Performers.Select(x => PerformerConverter.ConvertToDTO(x)).ToList());

            File.WriteAllText("Performers.json", jsonString);
        }

        public void Deserialise()
        {
            if (File.Exists("Performers.json"))
            {
                List<PerformerDTO> deserialisedPerformer = JsonConvert.DeserializeObject<List<PerformerDTO>>(File.ReadAllText("Performers.json"));

                if (deserialisedPerformer is null) return;

                foreach (Performer performer in deserialisedPerformer.Select(x => PerformerConverter.ConvertToModel(x)))
                {
                    Add(performer);
                }
            }
            else
            {
                using (var sw = File.CreateText("Performers.json"))
                {
                    sw.WriteLine("[]");
                }
            }
        }
    }
}
