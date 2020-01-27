using InternetRadio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace InternetRadio.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private Radio _radio;
        public Radio Radio 
        {
            get { return _radio; }
            set { SetProperty(ref _radio, value); }
        }

    }
}
