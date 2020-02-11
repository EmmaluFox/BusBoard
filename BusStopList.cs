using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic;
using RestSharp;

namespace BusBoard
{
    public class BusStopList
    {
        public string NearestStop = "";
        public string SecondNearestStop = "";
        public List<BusStop> BusStops = new List<BusStop>();
        
        public List<BusStop> BusStopFetcher(string busUrl)
        {
            var client = new RestClient(busUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var response = client.Get<List<BusStop>>(request);
            return response.Data;
        }

        public void BusStopsOrderByDistance()
        {
            List<BusStop> closestStops = new List<BusStop>(BusStops.OrderBy(distance => distance).Take(2));BusStops.OrderBy(distance => distance).Take(2);
            int counter = 1;
            foreach (var stop in closestStops)
            {
                if (counter == 1)
                {
                    NearestStop = (stop.Distance + stop.Id + stop.Indicator);
                } else if (counter == 2)
                {
                    SecondNearestStop = (stop.Distance + stop.Id + stop.Indicator);
                }
                counter++;
            }
            Console.WriteLine(NearestStop);
            Console.WriteLine(SecondNearestStop);
        }

        

        public static string FindByStopId()
        {
            Console.WriteLine("Please enter the stop ID:\n");
            string stopId = Console.ReadLine();
            string postcodeUrl = $@"https://api.tfl.gov.uk/StopPoint/{stopId}/Arrivals?app_id=0f9fc04c&app_key=4931529051075c3fc6489d889a0df590";
            return postcodeUrl;
        }
       

        public string StopName(IEnumerable<Arrivals> arrivals)
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