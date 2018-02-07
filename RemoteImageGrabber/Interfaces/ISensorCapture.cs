using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace RemoteImageGrabber.Interfaces
{
    public interface ISensorCaptureService
    {
        Task<BitmapImage> GetImageAsBitmapImage();
        Task<Byte[]> GetImageAsByteArray();
    }
}
