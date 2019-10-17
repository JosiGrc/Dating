using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dating.Models
{
    public class GoogleGeocodeAPI
    {
        public string State { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
    }
}