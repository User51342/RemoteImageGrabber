using Windows.Media.Capture;

namespace RemoteImageGrabber.Models
{
    public class MediaCaptureSingleton
    {
        public static MediaCapture Instance
        {
            get
            {
                return Nested.Instance;
            }
        }
        private MediaCaptureSingleton()
        { }

        internal class Nested
        {
            static Nested()
            { }

            internal static MediaCapture Instance = new MediaCapture();
        }
    }
}
