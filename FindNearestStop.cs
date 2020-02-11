using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using RestSharp;

namespace BusBoard
{
    public class FindNearestStop
    {
        public void StopFinder()
        {
            string url = BusStopList.FindByPostCode();
            PostCode postcodeFeatures = PostCodeList.PostCodeFetcher(url);
    
            string stopName = postcodeFeatures.AdminWard;
            decimal stopLat = postcodeFeatures.Latitude;
            decimal stopLon = postcodeFeatures.Longitude;
            string busUrl = BusStopList.FindByGeoLoc();
            List<BusStop> busStops = new List<BusStop>(BusStopList.BusStopFetcher(busUrl)
                .OrderBy();
        }
        
    }
}
