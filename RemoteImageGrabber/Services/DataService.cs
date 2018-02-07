using System.Threading.Tasks;
using RemoteImageGrabber.GrabberServiceProxy;
using RemoteImageGrabber.Interfaces;

namespace RemoteImageGrabber.Services
{
    public class DataService : IDataService
    {
        public async Task<string> GetCommand()
        {
            var client = new GrabberServiceClient();
            return await client.GetCommandAsync();
        }

        public async Task<int> SendImage(byte[] image)
        {
            var client = new GrabberServiceClient();
            return await client.SendImageAsync(image);
        }
    }
}
