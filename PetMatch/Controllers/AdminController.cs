using PetMatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetMatch.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var model = new AdminIndexViewModel();

            return View(model);
        }

        public ActionResult PetAnimal()
        {
            var model = new PetAnimalIndexViewModel();

            model.CreateViewModel = new PetAnimalCreateViewModel();

            return View(model);
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
                    return RedirectToAction("PetAnimal", "Admin");
                }

                ModelState.AddModelError("NotIsValid", animal.ValidationMessage);
            }

            return View("PetAnimal", new PetAnimalIndexViewModel { CreateViewModel = model });
            //return PartialView("CreatePartial", model);
        }

        [HttpPost]
        // TODO: Fix this hack
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PetAnimalCreateViewModel model)
        {
            return View("PetAnimal", new PetAnimalIndexViewModel { CreateViewModel = model });
        }
    }
}