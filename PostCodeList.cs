using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class PostCodeList
    {
        public static List<PostCode> PostCodeFetcher(string url)
        {
            var client = new RestClient(url) {Timeout = -1};
            var request = new RestRequest(Method.GET);
            var response = client.Get<List<PostCode>>(request);
            return response.Data;
        }
        
    }
}