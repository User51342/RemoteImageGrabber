namespace RemoteImageGrabber.DataServices
{
    public interface IStorage
    {
        int StoreImage(byte[] image);
    }
}
