using System;
using System.Collections.Generic;
using RestSharp;


namespace BusBoard
{
    public class StopPoint
    {
        public List<Arrivals> StopPointArrivals()
        {
            BusStop busStop = new BusStop();
            var thisStop = busStop.StopChooser();
            var url = $@"https://api.tfl.gov.uk/StopPoint/{thisStop}/Arrivals?app_id=0f9fc04c&app_key=4931529051075c3fc6489d889a0df590";
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var response = client.Get<List<Arrivals>>(request);
            return response.Data;
        }
    }
}