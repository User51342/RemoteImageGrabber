using RemoteImageGrabber.Interfaces;
using RemoteImageGrabber.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace RemoteImageGrabber.Services
{
    public class SensorCaptureService : ISensorCaptureService
    {
        const string fileName = "TestPhoto.jpg";
        public async Task<BitmapImage> GetImageAsBitmapImage()
        {
            var storageFile = await CaptureImageToStorageFile();
            var bmpImage = new BitmapImage(new Uri(storageFile.Path));
            return bmpImage;
        }

        private static async Task<StorageFile> CaptureImageToStorageFile()
        {
            var properties = ImageEncodingProperties.CreateJpeg();
            var storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await MediaCaptureSingleton.Instance.CapturePhotoToStorageFileAsync(properties, storageFile);
            return storageFile;
        }

        public async Task<byte[]> GetImageAsByteArray()
        {
            var storageFile = await CaptureImageToStorageFile();
            var buffer = File.ReadAllBytes(storageFile.Path);
            return buffer;
        }
    }
}
