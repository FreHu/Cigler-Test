﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cigler_Telerik.Application;
using Cigler_Telerik.Application.Ares;
using Cigler_Telerik.DAL;
using Cigler_Telerik.Models.Entities;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Cigler.Controllers
{
    public class PeopleController : Controller
    {
        private CiglerContext db = new CiglerContext();

		public ActionResult People_Read([DataSourceRequest]DataSourceRequest request)
		{
			IQueryable<Person> products = db.People;
			DataSourceResult result = products.ToDataSourceResult(request);
			return Json(result);
		}


		// GET: People
		public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,IC,DIC")] Person person)
        {
	        if (ModelState.IsValid)
	        {
		        db.People.Add(person);
		        db.SaveChanges();

		        return RedirectToAction("Index");
	        }
	        return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,IC,DIC")] Person person)
        {
		    if (ModelState.IsValid)
		    {
			    db.Entry(person).State = EntityState.Modified;
			    db.SaveChanges();
			    return RedirectToAction("Index");
		    }
	        ModelState.Clear(); // will stop the site from displaying invalid values on postback
	        var p = db.People.Find(person.Id); //addresses did not get included when the validation failed for some reason
	        Console.WriteLine();
	        return View(p);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
