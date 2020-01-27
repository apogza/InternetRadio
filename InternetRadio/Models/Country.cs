using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InternetRadio.Models
{
    [DataContract]
    public class Country : BaseModel
    {
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name="stationcount")]
        public int StationCount { get; set; }
    }
}   
