using Macronix_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Macronix_MVC.Controllers
{
    public class PeopleoFormController : Controller
    {
        private static List<PeopleForm> personList = new List<PeopleForm>();

        public ActionResult Index()
        {
            return View(personList);
        }


        public ActionResult Create()
        {
            var model = new PeopleForm
            {
                IsEditMode = false  
            };
            return View(model);
        }

        // POST: PeopleForm/Create
        [HttpPost]
        public ActionResult Create(PeopleForm person)
        {
            if (ModelState.IsValid)
            {
                personList.Add(person);
                return RedirectToAction("Index");
            }


            return View(person);
        }
  
        [HttpPost]
   
        public ActionResult Delete(int index)
        {
            if (index >= 0 && index < personList.Count)
            {
                personList.RemoveAt(index);
            }

            return RedirectToAction("Index");
        }

    
        public ActionResult Edit(int id)
        {
            var person = personList[id]; 
            person.IsEditMode = true;
            return View(person);
        }

        [HttpPost]
  
        public ActionResult Edit(PeopleForm editedPerson)
        {
            if (ModelState.IsValid)
            {
                var existingPerson = personList.FirstOrDefault(p => p.Id == editedPerson.Id);
                if (existingPerson != null)
                {
                    existingPerson.Name = editedPerson.Name;
                    existingPerson.Age = editedPerson.Age;
                    existingPerson.Date = editedPerson.Date;
                }

                return RedirectToAction("Index");
            }

            return View(editedPerson);
        }


    }
}
