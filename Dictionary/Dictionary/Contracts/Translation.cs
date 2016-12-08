using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Dictionary.Api
{
    [DataContract]
    public class Translation
    {
        [DataMember]
        public string German { get; set; }

        [DataMember]
        public string English { get; set; }
    }
}