using LibraryFor2ndLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.Repository
{
    interface IRepository<T> where T : Entity
    {
        T GetById(long id);
        void Add(T entity);

    }
}
