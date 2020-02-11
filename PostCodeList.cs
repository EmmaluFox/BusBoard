using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class PostCodeList
    {
        public static PostCode PostCodeFetcher(string url)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var response = client.Get<PostCode>(request);
            return response.Data;
        }
        
        
        
    }
}