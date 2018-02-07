using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RemoteImageGrabber.DataAccess.Entities;
using RemoteImageGrabber.DataAccess.Interfaces;

namespace RemoteImageGrabber.DataAccess
{
    public class SqlRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields
        private readonly SqlContext _context;
        private readonly DbSet _objectSet;
        #endregion

        #region Contruction / Initialization /Deconstruction
        public SqlRepository(SqlContext context)
        {
            _context = context;
            _objectSet = _context.Set<T>();
        }
        #endregion

        #region Public implementations
        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }

        public void Update(T entity)
        {
            var updateEntity = (T)_objectSet.Find(entity.Id);
            if (updateEntity != null)
            {
                _context.Entry(updateEntity).CurrentValues.SetValues(entity);
            }
        }

        public void Remove(T entity)
        {
            _objectSet.Remove(entity);
        }

        public T Find(int id)
        {
            return (T)_objectSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _objectSet.Cast<T>().ToList();
        }
        #endregion
    }
}
