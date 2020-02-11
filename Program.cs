using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    class Program
    {
        private const int Option1 = 1;
        private const int Option2 = 2;
        static void Main(string[] args)
        {
            int choice = ChooseMode.ChooseFindMode();
            if (choice == Option1)
            {
                BusStop.FindByPostCode();
            } else if (choice == Option2)
            {
                string stopSearchUrl = BusStop.FindByStopId();
                List<Arrivals> arrivals = new List<Arrivals>(ArrivalsList.ArrivalsFetcher(stopSearchUrl)
                    .OrderBy(stopPointArrival => stopPointArrival.TimeToStation)
                    .Take(5));
                PrintArrivals.ArrivalsPrinter(arrivals);
            }
        }

     
    }
}