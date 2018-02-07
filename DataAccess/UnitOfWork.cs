using RemoteImageGrabber.DataAccess.Entities;
using RemoteImageGrabber.DataAccess.Interfaces;

namespace RemoteImageGrabber.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly SqlContext _context;
        private SqlRepository<Command> _Commands;
        #endregion

        #region Properties
        private SqlRepository<Picture> _pictures;

        public SqlRepository<Picture> Pictures
        {
            get
            {
                if (_pictures == null)
                {
                    _pictures = new SqlRepository<Picture>(_context);
                }
                return _pictures;
            }
        }

        public SqlRepository<Command> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    _Commands = new SqlRepository<Command>(_context);
                }
                return _Commands;
            }
        }

        #endregion

        #region Construction / Initialization / Deconstruction
        public UnitOfWork()
        {
           _context = new SqlContext();
        }
        #endregion

        #region Public implementations
        public void Commit()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
