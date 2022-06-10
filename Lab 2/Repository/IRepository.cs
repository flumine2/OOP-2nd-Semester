using LibraryFor2ndLab;

namespace Lab_2.Repository
{
    interface IRepository<T> where T : Entity
    {
        T GetById(long id);
        void Add(T entity);

        void Serialise();
        void Deserialise();
    }
}
