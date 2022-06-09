using LibraryFor2ndLab;
using System.Collections.Generic;
using System.Linq;

namespace Lab_2.Repository
{
    class UserRepository : IRepository<User>
    {
        private readonly List<User> _base;

        public UserRepository()
        {
            _base = new List<User>();
        }

        public void Add(User entity)
        {
            _base.Add(entity);
        }

        public User GetById(long id)
        {
            User[] users = _base.Where(x => x.Id == id).ToArray();
            if (users.Length > 0)
            {
                return users[0];
            }
            else
            {
                return null;
            }
        }
    }
}
