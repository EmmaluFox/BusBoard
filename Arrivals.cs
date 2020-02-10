using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class Arrivals
    {
        public Arrivals(string route, string destination, DateTime expected)
        {
            Route = route;
            Destination = destination;
            Expected = expected;
        }

        private string Route { get; }
        private string Destination { get; }
        private DateTime Expected { get; }

        public void ArrivalsFormatter()
        {
        }
        
        public string ArrivalsBoard()
        {
            StopPoint stopPoint = new StopPoint();
            stopPoint.StopPointArrivals();
            var arrivals = "";
            return arrivals;
        }

    }
}