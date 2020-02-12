using System;
using System.Collections.Generic;

namespace BusBoard
{
    public class Printer
    {
        public void ArrivalsPrinter(List<Arrivals> arrivals)
        {
            var busStopList = new BusStopList();
            var busStop = busStopList.StopName(arrivals);
            Console.WriteLine("");
            Console.WriteLine(busStop + " Arrivals:\n");
            var header = string.Format("{0,-0}{1,-9}{2,-9}{3,-4}", "Due", "", "Route", "Destination");
            var arrivalsList = new ArrivalsList();
            Console.WriteLine(header);
            Console.WriteLine(arrivalsList.ArrivalsBoard(arrivals));
        }

        public void BusStopPrinter(List<BusStop> busStops)
        {
        }
    }
}