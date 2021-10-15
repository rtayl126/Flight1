using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight1.Data
{
    
        public interface IPersonDAO
        {
            public IEnumerable<Person> GetPeople();

            public Person GetPerson(int id);

            public void AddPerson(Person person);

            public void UpdatePerson(Person person);

            public void DeletePerson(int id);

        }
    
}
