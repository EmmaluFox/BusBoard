using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            ChooseMode.ChooseFindMode();
            string stopSearchUrl = BusStop.FindByStopId();
            List<Arrivals> arrivals = new List<Arrivals>(ArrivalsList.ArrivalsFetcher(stopSearchUrl).OrderBy(stopPointArrival => stopPointArrival.TimeToStation)
                .Take(5));
            PrintArrivals.ArrivalsPrinter(arrivals);
            
        }

     
    }
}