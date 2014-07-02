using PetMatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetMatch.Controllers
{
    public class PetAnimalController : Controller
    {
        // GET: PetAnimal
        public ActionResult Index()
        {
            var model = new PetAnimalIndexViewModel();
            model.CreateViewModel = new PetAnimalCreateViewModel();
            return View(model);
        }

        // GET: PetAnimal/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        [HttpPost]
        // TODO: Fix this hack
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetAnimalCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var animal = new PetMatch.Web.PetAnimal()
                {
                    Name = model.Name,
                    Visible = model.Visible,
                    DateCreated = DateTime.UtcNow,
                    // TODO: Fix this hack
                    CreatedBy = "dcruz" //User.Identity.Name
                };

                if (animal.IsValid)
                {
                    animal.AcceptChanges();
                    return RedirectToAction("Index", "PetAnimal");
                }

                ModelState.AddModelError("NotIsValid", animal.ValidationMessage);
            }

            return View("Index", new PetAnimalIndexViewModel { CreateViewModel = model });
            //return PartialView("CreatePartial", model);
        }

        // GET: PetAnimal/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: PetAnimal/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PetAnimal/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: PetAnimal/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
