using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCPetAdoption.Models;
using MVCPetAdoption.DataContexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCPetAdoption.Controllers
{
    public class PetController : Controller
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private PetDb petDb = new PetDb();
        private IdentityDb idDb = new IdentityDb();

        public PetController()
        {
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.idDb));
        }

        // GET: /Pet/
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            var pets = petDb.Pets.Include(p => p.Species).Include(p => p.User);
            return View(pets.ToList());
        }

        // GET: /Pet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                RedirectToAction("~/Home/");
            }
            Pet pet = petDb.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: /Pet/Create
        public ActionResult Create()
        {
            ViewBag.SpeciesId = new SelectList(petDb.Species, "SpeciesId", "SpeciesName");
            ViewBag.UserId = new SelectList(petDb.ServiceUsers, "UserId", "Name");
            return View();
        }

        // POST: /Pet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PetId,SpeciesId,Name,Breed,Age,Description,Diet,PetPictureUrl,ServiceUserId")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindById(User.Identity.GetUserId());
                int serviceUserId = petDb.ServiceUsers.SingleOrDefault(u => u.Email == user.Email).ServiceUserId;
                pet.ServiceUserId = serviceUserId;
                petDb.Pets.Add(pet);
                petDb.SaveChanges();
                return RedirectToAction("Success", "Home");
            }

            ViewBag.SpeciesId = new SelectList(petDb.Species, "SpeciesId", "SpeciesName", pet.SpeciesId);
            ViewBag.UserId = new SelectList(petDb.ServiceUsers, "UserId", "Name", pet.ServiceUserId);
            return View(pet);
        }

        // GET: /Pet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = petDb.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpeciesId = new SelectList(petDb.Species, "SpeciesId", "SpeciesName", pet.SpeciesId);
            ViewBag.UserId = new SelectList(petDb.ServiceUsers, "UserId", "Name", pet.ServiceUserId);
            return View(pet);
        }

        // POST: /Pet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PetId,SpeciesId,Name,Breed,Age,Description,Diet,PetPictureUrl,UserId")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                petDb.Entry(pet).State = EntityState.Modified;
                petDb.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpeciesId = new SelectList(petDb.Species, "SpeciesId", "SpeciesName", pet.SpeciesId);
            ViewBag.UserId = new SelectList(petDb.ServiceUsers, "UserId", "Name", pet.ServiceUserId);
            return View(pet);
        }

        // GET: /Pet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = petDb.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: /Pet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = petDb.Pets.Find(id);
            petDb.Pets.Remove(pet);
            petDb.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                petDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
