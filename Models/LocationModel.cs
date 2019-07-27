using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcuityHome.Models

{
    public class LocationModel
    {
        public string Latitude { get; set; }
        public StreetModel Street { get; set; }
        public string Longitude { get; set; }

    }
}