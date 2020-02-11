using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using RestSharp;

namespace BusBoard
{
    static class Program
    {
        private const int Option1 = 1;
        private const int Option2 = 2;
        static void Main(string[] args)
        {
            BusBoardApp();
        }

        static void BusBoardApp(IEnumerable<Arrivals> arrivals)
        {
            ArrivalsList arrivalsIn = new ArrivalsList();
            
            WelcomeMessage();
            ModeChoice();  
            PrintArrivals printArrivals = new PrintArrivals();
            printArrivals.ArrivalsPrinter(arrivals);
        }

        static void ModeChoice()
        {
            int choice = ChooseMode.ChooseFindMode();
            if (choice == Option1)
            {
                FindNearestStop fetchPostcode = new FindNearestStop();
                string busUrl = fetchPostcode.FindByGeoLoc();
                BusStopList fetchStopList = new BusStopList();
                fetchStopList.BusStopFetcher(busUrl);
                fetchStopList.BusStopsOrderByDistance();

            }
            else if (choice == Option2)
            {
                string stopSearchUrl = BusStopList.FindByStopId();
                List<Arrivals> arrivals = new List<Arrivals>(ArrivalsList.ArrivalsFetcher(stopSearchUrl)
                    .OrderBy(stopPointArrival => stopPointArrival.TimeToStation)
                    .Take(5));
                PrintArrivals.ArrivalsPrinter(arrivals);
            }
            else
            {
                BusBoardApp();
            } 
        }

        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to BusBoard!\n");
        }

        
    }
}