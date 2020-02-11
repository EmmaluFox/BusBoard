using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using RestSharp;

namespace BusBoard
{
    public class BusStopList
    {
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