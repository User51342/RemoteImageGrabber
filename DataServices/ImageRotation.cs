using System.Drawing;

namespace RemoteImageGrabber.DataServices
{
    public class ImageRotation
    {
        public static void Rotate(string imagePath, RotateFlipType rotateFlipType)
        {
            var bitmap1 = (Bitmap)Image.FromFile(imagePath);
            bitmap1.RotateFlip(rotateFlipType);
            bitmap1.Save(imagePath);
        }
    }
}