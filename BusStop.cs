using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class BusStop
    {
        private static string _stopId = "";
        public static string StopChooser()
        {
           Console.WriteLine("Please enter the stop ID:");
           Console.WriteLine("");
           _stopId = Console.ReadLine();
           var url = $@"https://api.tfl.gov.uk/StopPoint/{_stopId}/Arrivals?app_id=0f9fc04c&app_key=4931529051075c3fc6489d889a0df590";

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