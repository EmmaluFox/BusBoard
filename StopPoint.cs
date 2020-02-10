using System;
using RestSharp;


namespace BusBoard
{
    public class StopPoint
    {
        public string StopPointArrivals()
        {
            StopId stopId = new StopId();
            var thisStop = stopId.StopChooser();
            var url = $@"https://api.tfl.gov.uk/StopPoint/{thisStop}/Arrivals?app_id=0f9fc04c&app_key=4931529051075c3fc6489d889a0df590";
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}