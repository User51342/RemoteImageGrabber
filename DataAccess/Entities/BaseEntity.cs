using System.ComponentModel.DataAnnotations;

namespace RemoteImageGrabber.DataAccess.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

