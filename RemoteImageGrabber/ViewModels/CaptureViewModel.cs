using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using RemoteImageGrabber.Interfaces;
using RemoteImageGrabber.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using RemoteImageGrabber.Common.Enums;

namespace RemoteImageGrabber.ViewModels
{
    public class CaptureViewModel : ViewModelBase
    {
        #region Fields
        private string _output = "Started";
        private CaptureElement _captureElement;
        private readonly ISensorCaptureService _sensorCaptureService;
        private readonly IDataService _dataService;
        private BitmapImage _imageSource;
        private int _imageTaken = 0;
        #endregion

        #region Properties
        public string Output
        {
            get => _output;
            set
            {
                _output = value;
                RaisePropertyChanged("Output");
            }
        }

        public CaptureElement CaptureElement
        {
            get
            {
                if(_captureElement == null)
                {
                    _captureElement = new CaptureElement();
                }
                return _captureElement;
            }

            set
            {
                _captureElement = value;
                RaisePropertyChanged();
            }
        }

        public BitmapImage ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                _imageSource = value;
                RaisePropertyChanged("ImageSource");
            }
        }
        #endregion

        #region Construction / Initialization / Deconstruction
        public CaptureViewModel()
        {}

        [PreferredConstructor]
        public CaptureViewModel(ISensorCaptureService sensorCaptureService, IDataService dataService) : base()
        {
            _sensorCaptureService = sensorCaptureService;
            _dataService = dataService;
            SetCaptureSource();
            SetTimer();
        }
        #endregion

        #region Private Implementations
        private async void SetCaptureSource()
        {
            await MediaCaptureSingleton.Instance.InitializeAsync();
            CaptureElement.Source = MediaCaptureSingleton.Instance;
            await MediaCaptureSingleton.Instance.StartPreviewAsync();
        }

        private void SetTimer()
        {
            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += OnTick;
            timer.Start();
        }

        private async void OnTick(object sender, object e)
        {
            try
            {
                if (await _dataService.GetCommand() == RemoteCommand.Grab.ToString())
                {
                    var image = await _sensorCaptureService.GetImageAsByteArray();
                    var fileSize = await _dataService.SendImage(image);
                    _imageTaken++;
                    Output = $"{_imageTaken} images taken.";
                }
            }
            catch (Exception ex)
            {
                Output = ex.Message;
            }
        }
        #endregion
    }
}
