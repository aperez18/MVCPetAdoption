using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPetAdoption.DataContexts;
using MVCPetAdoption.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCPetAdoption.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private PetDb db = new PetDb();
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
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
            ViewBag.UserId = new SelectList(db.ServiceUsers, "UserId", "Name", pet.ServiceUserId);
            return View(pet);
        }

        // POST: /Pet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetId,SpeciesId,Name,Breed,Age,Description,Diet,PetPictureUrl,UserId")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "SpeciesName", pet.SpeciesId);
            ViewBag.UserId = new SelectList(db.ServiceUsers, "UserId", "Name", pet.ServiceUserId);
            return View(pet);
        }
	}
}