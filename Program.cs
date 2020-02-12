using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    internal static class Program
    {
        private const int Option1 = 1;
        private const int Option2 = 2;

        private static void Main(string[] args)
        {
            BusBoardApp();
        }

        private static void BusBoardApp()
        {
            WelcomeMessage();
            ModeChoice();
        }

        private static void ModeChoice()
        {
            var choice = ChooseMode.ChooseFindMode();
            if (choice == Option1)
            {
                Console.WriteLine("Please enter a PostCode:\n");
                var fetchPostcode = new FindNearestStop();
                var postCodeUrl = fetchPostcode.FindByPostCode();
                var postCode = new PostCode("", 0, 0);
                var busStopList = new BusStopList();
                fetchPostcode.PostCodeFetcher(postCodeUrl, postCode);
                var busStopUrl = fetchPostcode.FindByGeoLoc(postCode);
                busStopList.BusStopFetcher(busStopUrl);
            }
            else if (choice == Option2)
            {
                Console.WriteLine("Please enter the stop ID:\n");
                var findStopById = new BusStopList();
                var stopSearchUrl = findStopById.FindByStopId();
                var arrivals = new List<Arrivals>(ArrivalsList.ArrivalsFetcher(stopSearchUrl)
                    .OrderBy(stopPointArrival => stopPointArrival.TimeToStation)
                    .Take(5));
                var printer = new Printer();
                printer.ArrivalsPrinter(arrivals);
            }
            else
            {
                BusBoardApp();
            }
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to BusBoard!\n");
        }
    }
}