using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using RestSharp;

namespace BusBoard
{
    public class PostCode
    {
        public string AdminWard { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

    }
}