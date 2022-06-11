using LibraryFor2ndLab.Converters;
using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models.Person;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_2.Repository
{
    class PerformerRepository : IRepository<Performer>
    {
        private readonly Dictionary<long, Performer> _base;

        public PerformerRepository()
        {
            _base = new Dictionary<long, Performer>();
        }

        public int Count
        {
            get => _base.Count;
        }

        public void Add(Performer entity)
        {
            if (!_base.ContainsKey(entity.Id))
            {
                _base.Add(entity.Id, entity);
            }
        }

        public Performer GetById(long id)
        {
            Performer[] performers = _base.Where(x => x.Key == id).Select(x => x.Value).ToArray();
            if (performers.Length > 0)
            {
                return performers[0];
            }
            else
            {
                return null;
            }
        }

        public Performer FindByUserId(long id)
        {
            if (_base.Count > 0)
            {
                return _base.Select(x => x.Value).Where(x => x.User.Id == id).First();
            }
            return null;
        }

        public void Serialise()
        {
            string jsonString = JsonConvert.SerializeObject(_base.Select(x => x.Value).Select(x => PerformerConverter.ConvertToDTO(x)).ToList());

            File.WriteAllText("Performers.json", jsonString);
        }

        public void Deserialise()
        {
            List<PerformerDTO> deserialisedPerformer = JsonConvert.DeserializeObject<List<PerformerDTO>>(File.ReadAllText("Performers.json"));

            foreach (Performer performer in deserialisedPerformer.Select(x => PerformerConverter.ConvertToModel(x)))
            {
                Add(performer);
            }
        }
    }
}
