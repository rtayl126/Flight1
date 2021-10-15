using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight1.Data
{
    public interface IflightDAO
    {
        public IEnumerable<Flight> GetFlights();

        public Flight GetFlight(int id);

        public void AddFlight(Flight flight);

        public void UpdateFlight(Flight flight);

        public void DeleteFlight(int id);

        public IEnumerable<Person> GetFlightPeople(int id);

        public void FlightAddPerson(Person person);

        public int CountPassangers(int id);
    }
}
