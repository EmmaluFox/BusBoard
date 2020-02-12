using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using RestSharp;

namespace BusBoard
{
    public class PostCode
    {
        public string AdminWard { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public PostCode(string adminWard, float latitude, float longitude)
        {
            AdminWard = adminWard;
            Latitude = latitude;
            Longitude = longitude;
        }

        

    }
}