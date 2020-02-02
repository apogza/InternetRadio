using InternetRadio.Models;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace InternetRadio.Controls
{
    public sealed partial class RadioStationsGrid : UserControl
    {
        public static DependencyProperty RadiosProperty =
            DependencyProperty.Register("Radios", typeof(IEnumerable<Radio>),
                typeof(RadioStationsGrid), new PropertyMetadata(default(IEnumerable<Radio>)));

        public IEnumerable<Radio> Radios
        {
            get { return (IEnumerable<Radio>)GetValue(RadiosProperty); }
            set { SetValue(RadiosProperty, value); }
        }

        public static DependencyProperty SelectedRadioProperty =
            DependencyProperty.Register("SelectedRadio", typeof(Radio),
                typeof(RadioStationsGrid), new PropertyMetadata(default(Radio)));

        public Radio SelectedRadio
        { 
            get { return (Radio)GetValue(SelectedRadioProperty); }
            set { SetValue(SelectedRadioProperty, value); }
        }

        public RadioStationsGrid()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var radio = ((Button)sender).Tag as Radio;

            if (radio != null)
            {
                NavigationService.ChangeRadioStation(radio);
            }
        }
    }
}
