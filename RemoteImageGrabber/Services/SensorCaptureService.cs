using RemoteImageGrabber.Interfaces;
using RemoteImageGrabber.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Graphics.Display;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using RemoteImageGrabber.Common;

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
          //  CheckCamera();
            var properties = ImageEncodingProperties.CreateJpeg();
            var storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await MediaCaptureSingleton.Instance.CapturePhotoToStorageFileAsync(properties, storageFile);
            return storageFile;
        }

        private async static void CheckCamera()
        {
            DeviceInformation _cameraDevice;
            var allVideoDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            DeviceInformation desiredDevice = allVideoDevices.FirstOrDefault(x => x.EnclosureLocation != null && x.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front);
            _cameraDevice = desiredDevice ?? allVideoDevices.FirstOrDefault();
            var crh = new CameraRotationHelper(_cameraDevice.EnclosureLocation);
            crh.OrientationChanged += OnOrientationChanged            ;
            Debug.WriteLine($"{crh.GetCameraCaptureOrientation()}");
        }

        private static void OnOrientationChanged(object sender, bool e)
        {
            Debug.WriteLine("OnOrientationChanged");
        }

        public async Task<byte[]> GetImageAsByteArray()
        {
            var storageFile = await CaptureImageToStorageFile();
            var buffer = File.ReadAllBytes(storageFile.Path);
            return buffer;
        }
    }
}
