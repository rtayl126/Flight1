using Flight1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonData
{
    public class Person
    {
        [Display(Name= "First Name")]
        public string fName { get; set; }

        [Display(Name = "Last Name")]
        public string lName { get; set; }

        public int age { get; set; }

        public string eMail { get; set; }

        public string  job { get; set; }

        public List<int> Bookings { get; set; }

        public List<Flight> FlightList{ get; set; }
    }
}
