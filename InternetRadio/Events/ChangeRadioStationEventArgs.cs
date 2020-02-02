using InternetRadio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetRadio.Events
{
    public class ChangeRadioStationEventArgs : EventArgs
    {
        public Radio Radio { get; set; }
    }
}
