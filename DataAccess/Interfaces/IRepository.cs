using System.Collections.Generic;

namespace RemoteImageGrabber.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T Find(int id);
        IEnumerable<T> GetAll();
    }
}
