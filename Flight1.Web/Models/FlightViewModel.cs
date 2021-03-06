using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight1.Web.Models
{
    public class FlightViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Take Off")]
        [DataType(DataType.DateTime)]
        public DateTime Departure { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Arrival { get; set; }

        [Display(Name = "Departure")]
        public String DepLocation { get; set; }

        public String Destination { get; set; }

        public int Capacity { get; set; }
    }
}
