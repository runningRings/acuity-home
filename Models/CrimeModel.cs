using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcuityHome.Models
{
    public class CrimeModel
    {
        public string Category { get; set; }
        public LocationModel Location {get; set;}
        public string Context { get; set; }
        
    }
}