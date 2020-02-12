using System;
using RestSharp;

namespace BusBoard
{
    public class FindNearestStop
    {
        public float LatFromPostCode;
        public float LonFromPostCode;

        public string FindByPostCode() //Asks for PostCode, reads user input and returns custom URL for API
        {
            var postCode = Console.ReadLine();
            var url = $@"http://api.postcodes.io/postcodes/{postCode}";
            return url;
        }

        public PostCode
            PostCodeFetcher(string postCodeUrl,
                PostCode postCode) //Gets PostCode area name, latitude and longitude from PostCode.io API
        {
            var client = new RestClient(postCodeUrl) {Timeout = -1};
            var request = new RestRequest(Method.GET);
            var response = client.Get<PostCode>(request);
            postCode = response.Data;
            return postCode;
        }

        private string Latitude(PostCode postCode)
        {
            LatFromPostCode = postCode.Latitude;
            var latitude = LatFromPostCode.ToString("N3");
            return latitude;
        }

        private string Longitude(PostCode postCode)
        {
            LonFromPostCode = postCode.Longitude;
            var longitude = LonFromPostCode.ToString("N3");
            return longitude;
        }

        public string FindByGeoLoc(PostCode postCode)
        {
            var lat = Latitude(postCode);
            var lon = Longitude(postCode);
            var busUrl =
                $@"https://api.tfl.gov.uk/Place?type=StopPoint&lat={lat}&lon={lon}&radius=200&categories=all&app_id=0f9fc04c&app_key=4931529051075c3fc6489d889a0df590";
            return busUrl;
        }
    }
}