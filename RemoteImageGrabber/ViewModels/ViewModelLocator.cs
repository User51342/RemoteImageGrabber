using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using RemoteImageGrabber.Interfaces;
using RemoteImageGrabber.Services;

namespace RemoteImageGrabber.ViewModels
{
    public class ViewModelLocator
    {
        #region Properties
        public CaptureViewModel CaptureViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CaptureViewModel>();
            }
        }
        #endregion

        #region Construction / Initialization / Deconstruction
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }
            SimpleIoc.Default.Register<ISensorCaptureService, SensorCaptureService>();
            SimpleIoc.Default.Register<IDataService, DataService>();
            SimpleIoc.Default.Register<CaptureViewModel>();
        }
        #endregion
    }
}
