using System;
using System.Collections.Generic;
using Flight1.Data;

namespace FlightConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            flightDAO dao = new flightDAO();

            List<Flight> flightList = new List<Flight>();
            flightList = (List<Flight>)dao.GetFlights();

            foreach(var flight in flightList)
            {
                Console.WriteLine("we made it");
                Console.WriteLine($"{flight.FlightId}: {flight.TakeOff}: {flight.Arrival}");
            }
            Console.WriteLine();
        }
    }
}
