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
    class UserRepository : IRepository<User>
    {
        private readonly DataBase _base;

        public UserRepository(DataBase dataBase)
        {
            _base = dataBase;
            Deserialise();
        }

        public void Add(User entity)
        {
            if (!_base.Users.Select(x => x.Id).Contains(entity.Id))
            {
                _base.Users.Add(entity);
            }
        }

        public User GetById(long id)
        {
            return _base.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> FindAllByRole(Role role)
        {
            return _base.Users.Where(x => x.Role == role).ToList();
        }

        public void Serialise()
        {
            string jsonString = JsonConvert.SerializeObject(_base.Users.Select(x => UserConverter.ConvertToDTO(x)).ToList());

            File.WriteAllText("Users.json", jsonString);
        }

        public void Deserialise()
        {
            if (File.Exists("Users.json"))
            {
                List<UserDTO> deserialisedUser = JsonConvert.DeserializeObject<List<UserDTO>>(File.ReadAllText("Users.json"));
                if (deserialisedUser is null)
                {
                    return;
                }

                foreach (User user in deserialisedUser.Select(x => UserConverter.ConvertToModel(x)))
                {
                    Add(user);
                }
            }
            else
            {
                using (var sw = File.CreateText("Users.json"))
                {
                    sw.WriteLine("[]");
                }
            }
        }
    }
}
