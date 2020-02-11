using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using RestSharp;

namespace BusBoard
{
    public class FindNearestStop
    {
        public string StopName;
        public static decimal StopLat;
        public static decimal StopLon;
        
        public void StopFinder()
        {
            PostCode postcodeFeatures = PostCodeEntry.PostCodeFetcher();
            StopName = postcodeFeatures.AdminWard;
            StopLat = postcodeFeatures.Latitude;
            StopLon = postcodeFeatures.Longitude;
            Console.WriteLine(StopName);
        }

        public void StopIdFromPostCode()
        {
            BusStopList busStopList = new BusStopList();
            List<BusStop> busStops = new List<BusStop>(busStopList.BusStopFetcher());
            foreach (var busStop in busStops)
            {
                
            }
        }
        
    }
}
