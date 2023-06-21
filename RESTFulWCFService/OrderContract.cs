using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTFulWCFService
{
    [DataContract]
    public class OrderContract
    {
        [DataMember]
        public string OrderID { get; set; }

        [DataMember]
        public string OrderDate { get; set; }

        [DataMember]
        public string ShippedDate { get; set; }

        [DataMember]
        public string ShipCountry { get; set; }

        [DataMember]
        public string OrderTotal { get; set; }
    }
}