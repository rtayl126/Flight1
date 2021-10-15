using Flight1.Data;
using Flight1.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight1.Web.Controllers
{
    public class PersonViewController : Controller
    {
        private readonly IPersonDAO _personDAO;

        public PersonViewController (IPersonDAO personDAO)
        {
            this._personDAO = personDAO;
        }

        // GET: PersonController
        [HttpGet]
        public IActionResult AllPersons()
        {
            IEnumerable<Person> mPerson = _personDAO.GetPeople();
            List<PersonViewModel> model = new List<PersonViewModel>();

            foreach (var person in mPerson)
            {
                PersonViewModel temp = new PersonViewModel
                {
                    PersonId = person.PersonId,
                    FName= person.FName,
                    LName = person.LName,
                    Age = person.Age,
                    Email = person.Email,
                    Job = person.Job
                };
                model.Add(temp);
            }

            return View(model);
        }

        // GET: PersonController/Details/5
        

        // GET: PersonController/Create
        public ActionResult PersonCreate()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonCreate([Bind] PersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                Person newPerson = new()
                {
                    FName = person.FName,
                    LName = person.LName,
                    Age = person.Age,
                    Email = person.Email,
                    Job = person.Job
                };
                _personDAO.AddPerson(newPerson);

                return RedirectToAction("AllPersons");
            }
            return View(person);
        }

        // GET: PersonController/Edit/5
        public IActionResult PersonEdit(int  id)
        {
            PersonViewModel PersonModel = new();
            Person temp = _personDAO.GetPerson(id);
            PersonModel.PersonId = id;
            PersonModel.FName = temp.FName;
            PersonModel.LName = temp.LName;
            PersonModel.Age = temp.Age;
            PersonModel.Email = temp.Email;
            PersonModel.Job = temp.Job;
            return View(PersonModel);

        }

        // POST: PersonController/Edit/5
        [HttpPost]
        public ActionResult PersonEdit(PersonViewModel person)
        {

            Person newPerson = new()
                {
                    PersonId = person.PersonId,
                    FName = person.FName,
                    LName = person.LName,
                    Age = person.Age,
                    Email = person.Email,
                    Job = person.Job
                };
                _personDAO.UpdatePerson(newPerson);

                return RedirectToAction("AllPersons");
            
            //return View(person);
        }

        
        //public IActionResult PersonDelete(int id)
        //{
        //    PersonViewModel PersonModel = new();
        //    Person temp = _personDAO.GetPerson(id);
        //    PersonModel.PersonId = id;
        //    PersonModel.FName = temp.FName;
        //    PersonModel.LName = temp.LName;
        //    PersonModel.Age = temp.Age;
        //    PersonModel.Email = temp.Email;
        //    PersonModel.Job = temp.Job;
        //    return View(PersonModel);

        //}

        
        
        public ActionResult PersonDelete(int id)
        {
            _personDAO.DeletePerson(id);
            Console.WriteLine(id);
            return RedirectToAction("AllPersons");
        }
        
        public IActionResult PersonDetails(int id)
        {
            PersonViewModel PersonModel = new();
            Person temp = _personDAO.GetPerson(id);
            PersonModel.PersonId = id;
            PersonModel.FName = temp.FName;
            PersonModel.LName = temp.LName;
            PersonModel.Age = temp.Age;
            PersonModel.Email = temp.Email;
            PersonModel.Job = temp.Job;
            return View(PersonModel);
        }
    }
}
