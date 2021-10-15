using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flight1.Web.Models
{
    public class PersonViewModel
    {

        public int PersonId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public int BookingId { get; set; }
    }
}
