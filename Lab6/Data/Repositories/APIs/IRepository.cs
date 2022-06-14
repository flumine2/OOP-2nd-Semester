using LibraryFor2ndLab.Models;

namespace Lab6.Data.Repositories.APIs
{
    interface IRepository<T> where T : Entity
    {
        T GetById(long id);
        void Add(T entity);

        void Serialise();
        void Deserialise();
    }
}
