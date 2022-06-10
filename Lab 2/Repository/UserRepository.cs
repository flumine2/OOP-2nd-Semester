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
    class UserRepository : IRepository<User>
    {
        private readonly Dictionary<long, User> _base;

        public UserRepository()
        {
            _base = new Dictionary<long, User>();
        }

        public int Count
        {
            get => _base.Count;
        }

        public void Add(User entity)
        {
            if (!_base.ContainsKey(entity.Id))
            {
                _base.Add(entity.Id, entity);
            }
        }

        public User GetById(long id)
        {
            User[] users = _base.Where(x => x.Key == id).Select(x => x.Value).ToArray();
            if (users.Length > 0)
            {
                return users[0];
            }
            else
            {
                return null;
            }
        }

        public List<User> FindAllByRole(Role role)
        {
            return _base.Select(x => x.Value).Where(x => x.Role == role).ToList();
        }

        public void Serialise()
        {
            string jsonString = JsonConvert.SerializeObject(_base.Select(x => x.Value).Select(x => UserConverter.ConvertToDTO(x)).ToList());

            File.WriteAllText("Users.json", jsonString);
        }

        public void Deserialise()
        {
            List<UserDTO> deserialisedUser = JsonConvert.DeserializeObject<List<UserDTO>>(File.ReadAllText("Users.json"));

            foreach (User user in deserialisedUser.Select(x => UserConverter.ConvertToModel(x)))
            {
                Add(user);
            }
        }
    }
}
