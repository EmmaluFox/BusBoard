using System;
using RestSharp;

namespace BusBoard
{
    public class StopId
    {
        public string StopChooser()
        {
           Console.WriteLine("Please enter the stop ID:");
           Console.WriteLine("");
           var stopId = Console.ReadLine();
           return stopId;
        }
        
        public void StopFormatter()
        {
        }
        
    }
}