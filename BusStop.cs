using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using RestSharp;

namespace BusBoard
{
    public class BusStop
    {
        public string Id {get; set; }
        public string Indicator { get; set; }
        public string CommonName { get; set; }
        public float Distance { get; set; }
        public List<LineGroup> Lines { get; set; }
        public List<Direction> AdditionalProperties { get; set; }

        public class LineGroup
        {
            public string NaptanIdReference { get; set; }
            public string LineIdentifier { get; set; }
        }
        public class Direction
        {
            public string Towards { get; set; }
            public string CompassPoint { get; set; }
        }
    }
}


