
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight1.Data
{
    public class Person
    {
        public int PersonId { get; set; }

        
        public string FName { get; set; }

        
        public string LName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string  Job { get; set; }

        public int BookingId { get; set; }



        public Person() { }

        public Person(string FName, string LName, int Age, string Email, string Job)
        {
            this.FName = FName;
            this.LName = LName;
            this.Age = Age;
            this.Email = Email;
            this.Job = Job;
        }
    }
}
