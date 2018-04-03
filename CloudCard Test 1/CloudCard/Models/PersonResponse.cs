using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Globalization;

namespace CloudCard.Models
{
    [DataContract(Name = "person_response")]
    public class PersonResponse
    {
        [DataMember(Name = "access_link")]
        public string Link { get; set; }

        [DataMember(Name = "user")]
        public Person Person { get; set; }
    }
}
