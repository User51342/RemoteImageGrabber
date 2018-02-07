using System;

namespace RemoteImageGrabber.DataAccess.Entities
{
    public class Picture : BaseEntity
    {
        public string PictureUrl { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
