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
                Console.WriteLine("Please enter a PostCode:\n");
                FindNearestStop fetchPostcode = new FindNearestStop();
                string postCodeUrl = fetchPostcode.FindByPostCode();
                PostCode postCode = new PostCode("",0,0);
                
                BusStopList busStopList = new BusStopList();
                
                string busStopUrl = fetchPostcode.FindByGeoLoc(postCode);
                busStopList.BusStopFetcher(busStopUrl);

            }
            else if (choice == Option2) 
            {
                Console.WriteLine("Please enter the stop ID:\n");
                BusStopList findStopById = new BusStopList();
                string stopSearchUrl = findStopById.FindByStopId();
                List<Arrivals> arrivals = new List<Arrivals>(ArrivalsList.ArrivalsFetcher(stopSearchUrl)
                    .OrderBy(stopPointArrival => stopPointArrival.TimeToStation)
                    .Take(5));
                Printer printer = new Printer();
                printer.ArrivalsPrinter(arrivals);
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