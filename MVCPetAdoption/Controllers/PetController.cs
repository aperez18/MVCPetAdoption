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

namespace MVCPetAdoption.Controllers
{
    public class PetController : Controller
    {
        private PetDb db = new PetDb();

        // GET: /Pet/
        public ActionResult Index()
        {
            var pets = db.Pets.Include(p => p.Species).Include(p => p.User);
            return View(pets.ToList());
        }

        // GET: /Pet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: /Pet/Create
        public ActionResult Create()
        {
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name");
            return View();
        }

        // POST: /Pet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PetId,SpeciesId,Name,Breed,Age,Description,Diet,PetPictureUrl,UserId")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName", pet.SpeciesId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", pet.UserId);
            return View(pet);
        }

        // GET: /Pet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName", pet.SpeciesId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", pet.UserId);
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
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName", pet.SpeciesId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", pet.UserId);
            return View(pet);
        }

        // GET: /Pet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
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
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
