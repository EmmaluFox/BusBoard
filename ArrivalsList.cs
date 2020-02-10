using System;
using System.Collections.Generic;
using RestSharp;
using System.Linq;


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

        public static string ArrivalsBoard(List<Arrivals> arrivals)
        {
            string arrivalsBoard = "";
            foreach (var arrival in arrivals)
            {
                int minutes = arrival.TimeToStation / 60;
                int seconds = arrival.TimeToStation % 60;
                string arrivalEntry = string.Format(("{0,-0}:{1,-4}{2,-0} - {3,5}"), minutes, seconds, arrival.LineName, arrival.DestinationName);
                arrivalsBoard += arrivalEntry;
            }

            return arrivalsBoard;
        }
    }
}