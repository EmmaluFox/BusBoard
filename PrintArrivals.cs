using System;
using System.Collections;
using System.Collections.Generic;


namespace BusBoard
{
    public class PrintArrivals
    {
        public void ArrivalsPrinter(IEnumerable<Arrivals> arrivals)
        {
            BusStopList busStopList = new BusStopList();
            string busStop = busStopList.StopName(arrivals);
            Console.WriteLine("");
            Console.WriteLine(busStop + " Arrivals:\n");
            string header = string.Format(("{0,-0}{1,-9}{2,-9}{3,-4}"),"Due","","Route","Destination");

            Console.WriteLine(header);
            ArrivalsList arrivalsList = new ArrivalsList();
            arrivalsList.ArrivalsBoard(IEnumerable<Arrivals> arrivals);
            Console.WriteLine(ArrivalsList.ArrivalsBoard(arrivals));
        }
    }
}