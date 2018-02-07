using System.Threading.Tasks;

namespace RemoteImageGrabber.Interfaces
{
    public interface IDataService
    {
        Task<string> GetCommand();
        Task<int> SendImage(byte[] image);
    }
}
