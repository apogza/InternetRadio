using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InternetRadio.Models
{
    [DataContract]
    public class Radio
    {
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name="url")]
        public string Url { get; set; }

        [DataMember(Name="favicon")]
        public string Icon { get; set; }

    }
}
