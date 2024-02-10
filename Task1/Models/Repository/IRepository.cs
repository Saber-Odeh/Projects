using System.Collections.Generic;

namespace Task1.Models.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(int Id, T entity);
        void Delete(int Id, T entity);
        List<T> Get();
        T Find(int Id);
    }
}
