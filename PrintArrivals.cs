using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace BusBoard
{
    public class PrintArrivals
    {
        public void ArrivalsPrinter(List<Arrivals> arrivals)
            {
                BusStopList busStopList = new BusStopList();
                string busStop = busStopList.StopName(arrivals);
                Console.WriteLine("");
                Console.WriteLine(busStop + " Arrivals:\n");
                string header = string.Format(("{0,-0}{1,-9}{2,-9}{3,-4}"),"Due","","Route","Destination");
                ArrivalsList arrivalsList = new ArrivalsList();
                Console.WriteLine(header);
                Console.WriteLine(arrivalsList.ArrivalsBoard(arrivals));
            }
    }
}