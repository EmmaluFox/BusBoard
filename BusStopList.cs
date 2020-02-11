using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using RestSharp;

namespace BusBoard
{
    public class BusStopList
    {
        
        public static List<BusStop> BusStopFetcher(string busUrl)
        {   var client = new RestClient(busUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var response = client.Get<List<BusStop>>(request);
            return response.Data;
        }
        public static string FindByGeoLoc()
        {
            FindNearestStop findByGeo = new FindNearestStop();
            findByGeo.StopFinder();
            string busUrl = $@"https://api.tfl.gov.uk/Place?type=StopPoint&lat={latitude}&lon={-longitude}&radius=200&categories=all&app_id=0f9fc04c&app_key=4931529051075c3fc6489d889a0df590";
            return busUrl;
        }

        public static string FindByStopId()
        {
            Console.WriteLine("Please enter the stop ID:\n");
            string stopId = Console.ReadLine();
            string postcodeUrl = $@"https://api.tfl.gov.uk/StopPoint/{stopId}/Arrivals?app_id=0f9fc04c&app_key=4931529051075c3fc6489d889a0df590";
            return postcodeUrl;
        }
        public static string FindByPostCode()
        {
            Console.WriteLine("Please enter a PostCode:\n");
            string postCode = Console.ReadLine();
            string url = $@"http://api.postcodes.io/postcodes/{postCode}";
            return url;
        }

        public static string StopName(List<Arrivals> arrivals)
        {
            string busStop = "";
            foreach (var arrival in arrivals)
            {
                busStop = arrival.StationName;
            }
            return busStop;
        }
        
        
    }
}