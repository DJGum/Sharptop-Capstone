using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Globalization;

namespace CloudCard.Models
{
    [DataContract(Name = "links")]
    public class Links
    {
        [DataMember(Name = "login")]
        public string Login { get; set; }
    }    
}
