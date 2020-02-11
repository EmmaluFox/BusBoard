using System;
using System.Collections.Generic;

namespace BusBoard
{
    public class PrintArrivals
    {
        public static void ArrivalsPrinter(List<Arrivals> arrivals)
        {
            string busStop = BusStopList.StopName(arrivals);
            Console.WriteLine("");
            Console.WriteLine(busStop + " Arrivals:\n");
            string header = string.Format(("{0,-0}{1,-9}{2,-9}{3,-4}"),"Due","","Route","Destination");

            Console.WriteLine(header);
            Console.WriteLine(ArrivalsList.ArrivalsBoard(arrivals));
        }
    }
}