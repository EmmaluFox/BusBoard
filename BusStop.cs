using System.Collections.Generic;

namespace BusBoard
{
    public class BusStop
    {
        public BusStop(float distance)
        {
            Distance = distance;
        }

        public string Id { get; set; }
        public string Indicator { get; set; }
        public string CommonName { get; set; }
        public float Distance { get; set; }
        public List<string> Lines { get; set; }
        public List<string> AdditionalProperties { get; set; }
        public string NaptanIdReference { get; set; }
        public string LineIdentifier { get; set; }
        public string Towards { get; set; }
        public string CompassPoint { get; set; }
    }
}