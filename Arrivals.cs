using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class Arrivals
    {
        public string LineName { get; set; }
        public string DestinationName { get; set; }
        public string StationName { get; set; }
        public int TimeToStation { get; set; }

        public void ArrivalsBoard()
        {
            StopPoint stopPoint = new StopPoint();
            var arrivals = stopPoint.StopPointArrivals();
            int limit = 1;
            string busStop = "";
            foreach (var arrival in arrivals)
            {
                busStop = arrival.StationName;
            }
            Console.WriteLine($@"{busStop} Arrivals:
");
            Console.WriteLine($@"      Due    Route    Destination");
            
            foreach (var arrival in arrivals)
            {
                var minutes = TimeToStation / 60;
                var seconds = TimeToStation % 60;
                if (limit < 5)
                {
                    Console.WriteLine($@"{limit}:     {minutes}:{seconds}    {LineName}    {DestinationName}");
                    
                    
                    limit++;
                }
            }
            
        }

    }
}