using System;
using System.Collections.Generic;
using RestSharp;
using System.Linq;

namespace BusBoard
{
    public class Arrivals
    {
        public string LineName { get; set; }
        public string DestinationName { get; set; }
        public string StationName { get; set; }
        public int TimeToStation { get; set; }

    }
}