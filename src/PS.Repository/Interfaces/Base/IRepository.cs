using System.Collections;
using System.Collections.Generic;

namespace PS.Repository.Interfaces.Base
{
    public interface IRepository<T>
    {
        T Insert(T obj);
        T Update(T obj);
        bool Remove(int id);
        T Read(int id);
        IEnumerable<T> GetAll();
    }
}