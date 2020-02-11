using System;
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
        static void BusBoardApp()
        {
            WelcomeMessage();
            ModeChoice();  
        }
        static void ModeChoice()
        {
            int choice = ChooseMode.ChooseFindMode();
            if (choice == Option1)
            {
                string url = BusStop.FindByPostCode();
                List<PostCode> postcode = new List<PostCode>(PostCodeList.PostCodeFetcher(url));
            }
            else if (choice == Option2)
            {
                string stopSearchUrl = BusStop.FindByStopId();
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