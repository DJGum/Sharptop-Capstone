using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Globalization;

namespace CloudCard.Models
{
    [DataContract(Name = "currentPhoto")]
    public class Photo
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}
