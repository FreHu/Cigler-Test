using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cigler_Telerik.DAL;
using Cigler_Telerik.Models.Entities;

namespace Cigler_Telerik.Controllers
{
    public class AddressController : Controller
    {
	    private CiglerContext db = new CiglerContext();
        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Address/Create
        public ActionResult Create(int personId)
        {
	        TempData["PersonId"] = personId;
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "PersonId, Id, Street, City, PSC")] Address address)
        {
            try
            {
	            if (ModelState.IsValid)
	            {
		            db.Addresses.Add(address);
		            db.SaveChanges();
	            }
                return RedirectToAction("Index","People");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Address address = db.Addresses.Find(id);
			if (address == null)
			{
				return HttpNotFound();
			}
			return View(address);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "PersonId,Id, Street,City,PSC")] Address address)
        {
            try
            {
	            if (ModelState.IsValid)
	            {
					db.Entry(address).State = EntityState.Modified;
					db.SaveChanges();
					return RedirectToAction("Edit","People",new {id=address.PersonId});
				}
                return RedirectToAction("Index","People");
            }
            catch
            {
                return View();
            }
        }


        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				var address = db.Addresses.Find(id);
				if (address != null)
				{
					var personId = address.PersonId;
					db.Addresses.Remove(address);
					db.SaveChanges();
					return RedirectToAction("Edit", "People", new { id = personId });
				}
			}
            catch
            {
                return View();
            }
	        return View();
        }
    }
}
