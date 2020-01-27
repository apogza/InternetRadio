using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InternetRadio.Models
{
    [DataContract]
    public class BaseModel
    {
        [IgnoreDataMember]
        public bool IsFavorite { get; set; }
    }
}
