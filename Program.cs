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
            string stopSearchUrl = BusStop.StopChooser();
            List<Arrivals> arrivals = new List<Arrivals>(ArrivalsList.ArrivalsFetcher(stopSearchUrl).OrderBy(stopPointArrival => stopPointArrival.TimeToStation)
                .Take(5));
            PrintArrivals.ArrivalsPrinter(arrivals);
            // string stopId = StopChooser.AskUserForStopCode();
            // List<Arrivals> arrivals = ArrivalsFetcher.GetArrivalsForStop(stopId);
            // BusBoard.PrintArrivals(arrivals)


        }

     
    }
}