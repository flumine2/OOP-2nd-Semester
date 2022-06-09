using LibraryFor2ndLab.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Lab_2.Repository
{
    class PerformerRepository : IRepository<Performer>
    {
        private readonly List<Performer> _base;
        private readonly UserRepository _userRepository;

        public PerformerRepository(UserRepository userRepository)
        {
            _userRepository = userRepository;
            _base = new List<Performer>();
        }

        public void Add(Performer entity)
        {
            _userRepository.Add(entity.User);
            _base.Add(entity);
        }

        public Performer GetById(long id)
        {
            Performer[] performers = _base.Where(x => x.Id == id).ToArray();
            if (performers.Length > 0)
            {
                return performers[0];
            }
            else
            {
                return null;
            }
        }
    }
}
