﻿using System;
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
                BusStopList fetchStopList = new BusStopList();
                Console.WriteLine("Please enter a PostCode:\n");
                FindNearestStop fetchPostcode = new FindNearestStop();
                string busUrl = fetchPostcode.FindByGeoLoc();
                
                fetchStopList.BusStopFetcher(busUrl);
                fetchStopList.BusStopsOrderByDistance();

            }
            else if (choice == Option2) 
            {
                Console.WriteLine("Please enter the stop ID:\n");
                BusStopList findStopById = new BusStopList();
                string stopSearchUrl = findStopById.FindByStopId();
                List<Arrivals> arrivals = new List<Arrivals>(ArrivalsList.ArrivalsFetcher(stopSearchUrl)
                    .OrderBy(stopPointArrival => stopPointArrival.TimeToStation)
                    .Take(5));
                PrintArrivals printArrivals = new PrintArrivals();
                printArrivals.ArrivalsPrinter(arrivals);
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