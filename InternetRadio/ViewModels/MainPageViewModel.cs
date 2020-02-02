using InternetRadio.Events;
using InternetRadio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace InternetRadio.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            NavigationService.ChangeRadioStationHandler += NavigationService_ChangeRadioStationHandler;
        }

        private void NavigationService_ChangeRadioStationHandler(object sender, ChangeRadioStationEventArgs e)
        {
            Radio = e.Radio;
        }

        private Radio _radio;

        public Radio Radio 
        {
            get { return _radio; }
            set 
            { 
                SetProperty(ref _radio, value);
                RadioStation = CreateMediaPlaybackSource(value);
            }
        }

        private IMediaPlaybackSource _radioStation;

        public IMediaPlaybackSource RadioStation
        {
            get { return _radioStation; }
            set { SetProperty(ref _radioStation, value); }
        }

        private IMediaPlaybackSource CreateMediaPlaybackSource(Radio radio)
        {
            Uri sourceUri = new Uri(radio.Url);
            return MediaSource.CreateFromUri(sourceUri);
        }
    }
}
