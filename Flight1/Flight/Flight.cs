using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight1.Data
{
   public class Flight
    {
        public int FlightId { get; set; }

        [DataType(DataType.Date)]
        public DateTime TakeOff { get; set; }

        [DataType(DataType.Date)]
        public DateTime Arrival { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }

        public int Capacity { get; set; }

        public Flight()
        {
        }
        public Flight(DateTime TakeOff, DateTime Arrival, string Departure, string Destination, int Capacity)
        {
            this.TakeOff = TakeOff;
            this.Arrival = Arrival;
            this.Departure = Departure;
            this.Destination = Destination;
            this.Capacity = Capacity;
        }
    }
}
