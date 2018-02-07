using System.Data.Entity;

namespace RemoteImageGrabber.DataAccess.Entities
{
    public class SqlContext : DbContext
    {
        #region Properties
        public virtual DbSet<Command> Commands { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        #endregion

        #region Construction / Initalization / Deconstruction
        public SqlContext() : base("name=RemoteGrabber")
        {
        }
        #endregion
    }
}
