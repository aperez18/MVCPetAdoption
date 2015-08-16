using MVCPetAdoption.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPetAdoption.Controllers
{
    public class StoreController : Controller
    { 
        PetDb db = new PetDb();
        // GET: Store
        public ActionResult Index() 
        {

            var species = db.Species.ToList();

            return View(species);
        }

        // GET: /Store/Browse?species=Dog
        public ActionResult Browse(string species)
        {
            // Retrieve Genre and its Associated Albums from databases
            var speciesModel = db.Species.Include("Pets").Single(s => s.SpeciesName == species);

            return View(speciesModel);
        }

        // GET: /Store/Details/Id
        public ActionResult Details(int id)
        {
            var pet = db.Pets.Find(id);
            return View(pet);
        }
    }
}