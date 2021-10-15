using Flight1.Data;
using Flight1.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight1.Web.Controllers
{
    public class FlightViewController : Controller
    {
        private readonly IflightDAO _flightDAO;

        public FlightViewController(IflightDAO flightDAO)
        {
            this._flightDAO = flightDAO;
        }

        [HttpGet]
        public IActionResult AllFlights()
        {
            IEnumerable<Flight> mFlight = _flightDAO.GetFlights();
            List<FlightViewModel> model = new List<FlightViewModel>();

            foreach (var flight in mFlight)
            {
                FlightViewModel temp = new FlightViewModel
                {
                   Id = flight.FlightId,
                   Departure = flight.TakeOff,
                   Arrival = flight.Arrival,
                    DepLocation = flight.Departure,
                    Destination = flight.Destination,
                    Capacity = flight.Capacity
                };

                model.Add(temp);
            }

            return View(model);
        }

        public ActionResult FlightCreate()
        {
            return View();
        }

        [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult FlightCreate([Bind] FlightViewModel flight)
        {
            if (ModelState.IsValid)
            {
                Flight newFlight = new()
                {
                    TakeOff = flight.Departure,
                    Arrival = flight.Arrival,
                    Departure = flight.DepLocation,
                    Destination = flight.Destination,
                    Capacity = flight.Capacity
                };
                _flightDAO.AddFlight(newFlight);

                return RedirectToAction("AllFlights");
            }
            return View(flight);
        }

        
        public IActionResult FlightDelete(int id)
        {
            FlightViewModel FlightModel = new();
            Flight temp = _flightDAO.GetFlight(id);

            FlightModel.Id = id;
            FlightModel.Departure = temp.TakeOff;
            FlightModel.Arrival = temp.Arrival;
            FlightModel.DepLocation = temp.Departure;
            FlightModel.Destination = temp.Destination;
            FlightModel.Capacity = temp.Capacity;

            return View(FlightModel);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FlightDelete(FlightViewModel flight)
        {
            Console.WriteLine(flight.Id);
            _flightDAO.DeleteFlight(flight.Id);
            return RedirectToAction("AllFlights");
        }


        public IActionResult FlightDetails(int id)
        {
             Flight model = _flightDAO.GetFlight(id);
              return View(model);
        }


        public IActionResult FlightEdit(int id)
        {
            FlightViewModel FlightModel = new();
            Flight temp = _flightDAO.GetFlight(id);

            FlightModel.Id = id;
            FlightModel.Departure = temp.TakeOff;
            FlightModel.Arrival = temp.Arrival;
            FlightModel.DepLocation = temp.Departure;
            FlightModel.Destination = temp.Destination;
            FlightModel.Capacity = temp.Capacity;

            return View(FlightModel);
        }

        [HttpPost]
        public ActionResult FlightEdit(FlightViewModel flight)
        {
            if (ModelState.IsValid)
            {
                Flight newFlight = new()
                {
                    FlightId = flight.Id,
                    TakeOff = flight.Departure,
                    Arrival = flight.Arrival,
                    Departure = flight.DepLocation,
                    Destination = flight.Destination,
                    Capacity = flight.Capacity
                };
                _flightDAO.UpdateFlight(newFlight);

                return RedirectToAction("AllFlights");
            }
            return View(flight);
        }

        [HttpGet]
        public IActionResult GetFlightPeoples(int id)
        {
            
            Flight flight = _flightDAO.GetFlight(id);
            
                IEnumerable<Person> mPerson = _flightDAO.GetFlightPeople(id);
                List<PersonViewModel> model = new List<PersonViewModel>();

                foreach (var person in mPerson)
                {
                    PersonViewModel temp = new PersonViewModel
                    {
                        PersonId = person.PersonId,
                        FName = person.FName,
                        LName = person.LName,
                        Age = person.Age,
                        Email = person.Email,
                        Job = person.Job
                    };
                    temp.BookingId = person.BookingId;
                    model.Add(temp);
                    Console.WriteLine(temp.PersonId);
                }
                return View(model);  
            


        }

        [HttpGet]
        public IActionResult AddFlightPeoples(int id)
        {
            int passengers = _flightDAO.CountPassangers(id);
            Console.WriteLine(passengers);
            Flight flight = _flightDAO.GetFlight(id);
            if (passengers < flight.Capacity)
            {
                
            }
                return RedirectToAction("FullFlight");
            

        }
    }
}
