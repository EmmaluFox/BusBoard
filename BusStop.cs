using System;
using RestSharp;

namespace BusBoard
{
    public class BusStop
    {
        
        
        public string StopChooser()
        {
           Console.WriteLine("Please enter the stop ID:");
           Console.WriteLine("");
           var stopId = Console.ReadLine();
           return stopId;
        }
        
      
        
    }
}