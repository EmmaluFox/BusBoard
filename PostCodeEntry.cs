using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class PostCodeEntry
    {
        public static PostCode PostCodeFetcher()
        {
            string url = BusStopList.FindByGeoLoc();
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var response = client.Get<PostCode>(request);
            return response.Data;
        }
        
        
        
    }
}