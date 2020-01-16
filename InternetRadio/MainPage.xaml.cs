using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Streaming.Adaptive;
using Windows.Media.Core;
using Windows.Media.Playback;
using System.Net.Http;
using System.Net;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InternetRadio
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Uri radioStation = new Uri("http://play.global.audio/radio1rock.opus");
        
        MediaSource mediaSource;
        MediaPlayer player;

        public MainPage()
        {
            this.InitializeComponent();
            
            mediaSource = MediaSource.CreateFromUri(radioStation);
            MseStreamSource mseStreamSource = new MseStreamSource();
            

            mediaPlayerElement.Source = mediaSource;
        }

        private void MediaPlayer_MediaOpened(Windows.Media.Playback.MediaPlayer sender, object args)
        {
            
        }

        private void MediaSource_StateChanged(MediaSource sender, MediaSourceStateChangedEventArgs args)
        {
            
        }
    }
}
