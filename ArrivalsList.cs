using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class ArrivalsList
    {

        public static List<Arrivals> ArrivalsFetcher(string stopSearchUrl)
        {
            var client = new RestClient(stopSearchUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var response = client.Get<List<Arrivals>>(request);
            return response.Data;
        }

        public string ArrivalsBoard(List<Arrivals> arrivals)
        {
            string arrivalsBoard = "";
            foreach (var arrival in arrivals)
            {
                int minutes = arrival.TimeToStation / 60;
                string min;
                if (minutes < 1)
                {
                    min = " min";
                }
                else
                {
                    min = " mins";
                }
                string arrivalEntry = string.Format(("{0,2}{1,-10}{2,-9}{3,-4}\n"), minutes, min, arrival.LineName, arrival.DestinationName);
                arrivalsBoard += arrivalEntry;
            }

            return arrivalsBoard;
        }
        
    }
}