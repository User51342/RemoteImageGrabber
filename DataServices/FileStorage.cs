using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using RemoteImageGrabber.DataAccess;
using RemoteImageGrabber.DataAccess.Entities;

namespace RemoteImageGrabber.DataServices
{
    public class FileStorage : IStorage
    {
        public int StoreImage(byte[] image)
        {
            var filePath = ConfigurationManager.AppSettings["FilePath"];
            var fileName = $"ImageGrab_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.jpg";
            var filePathAndName = Path.Combine(filePath,fileName);
            File.WriteAllBytes(filePathAndName, image);
            ImageRotation.Rotate(filePathAndName, RotateFlipType.Rotate90FlipNone);
            RecordFileName(fileName);
            var fileSize = (int)new FileInfo(filePathAndName).Length;
            return fileSize;
        }

        private void RecordFileName(string fileName)
        {
            var uow = new UnitOfWork();
            uow.Pictures.Add(new Picture() { PictureUrl = fileName, CreationDate = DateTime.Now});
            uow.Commit();
        }
    }
}