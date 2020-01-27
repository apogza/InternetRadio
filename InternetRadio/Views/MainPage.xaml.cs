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
using InternetRadio.ViewModels;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InternetRadio.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Uri radioStation = new Uri("http://play.global.audio/radio1rock.opus");
        
        MediaSource mediaSource;

        public MainPageViewModel ViewModel { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            InitNavigation();
            
            mediaSource = MediaSource.CreateFromUri(radioStation);            

            mediaPlayerElement.Source = mediaSource;
        }

        private void InitNavigation()
        {
            NavigationService.ContentFrame = ContentFrame;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (ViewModel == null)
            {
                ViewModel = new MainPageViewModel();
            }
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem item = args.InvokedItemContainer as NavigationViewItem;

            if (item?.Tag == null)
            {
                return;
            }

            NavigationService.NavigateTo(item.Tag.ToString());
        }

    }
}
