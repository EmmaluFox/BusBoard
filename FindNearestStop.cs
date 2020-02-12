using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class FindNearestStop
    {
        public static decimal LatFromPostCode;
        public static decimal LonFromPostCode;
        private string _postCodeUrl;
        
        
        public PostCode StopFinder() //Creates PostCode object. Updates values of Lat & Lon.
        {
            FindNearestStop fetchPostCode = new FindNearestStop();
            PostCode postCode = fetchPostCode.PostCodeFetcher();
            return postCode;
        }
        private string FindByPostCode() //Asks for PostCode, reads user input and returns custom URL for API
        {
            string postCode = Console.ReadLine();
            string url = $@"http://api.postcodes.io/postcodes/{postCode}";
            return url;
        }

        private PostCode PostCodeFetcher() //Gets PostCode area name, latitude and longitude from PostCode.io API
        {
            _postCodeUrl = FindByPostCode();
            var client = new RestClient(_postCodeUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var response = client.Get<PostCode>(request);
            return response.Data;
        }

        public string Latitude()
        {
            LatFromPostCode = StopFinder().Latitude;
            string latitude = LatFromPostCode.ToString("N3");
            return latitude;
        }
        public string Longitude()
        {
            LonFromPostCode = StopFinder().Longitude;
            string longitude = LonFromPostCode.ToString("N3");
            return longitude;
        }
        public string FindByGeoLoc()
        {
            string lat = Latitude();
            string lon = Longitude();
            string busUrl = $@"https://api.tfl.gov.uk/Place?type=StopPoint&lat={lat}&lon={lon}&radius=200&categories=all&app_id=0f9fc04c&app_key=4931529051075c3fc6489d889a0df590";
            return busUrl;
        }
        
    }
}
