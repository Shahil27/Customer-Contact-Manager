using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Customer_Contact_Manager.DAL;
using Customer_Contact_Manager.Models;

namespace Customer_Contact_Manager.Controllers
{
    public class CustomerContactController : Controller
    {
        private Context db = new Context();

        // GET: CustomerContact
        public ActionResult Index()
        {
            var customerContacts = db.CustomerContacts.Include(c => c.Customer);
            return View(customerContacts.ToList());
        }

        // GET: CustomerContact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerContact customerContact = db.CustomerContacts.Find(id);
            if (customerContact == null)
            {
                return HttpNotFound();
            }
            return View(customerContact);
        }

        // GET: CustomerContact/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            return View();
        }

        // POST: CustomerContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerID,Name,Email,ContactNumber")] CustomerContact customerContact)
        {
            if (ModelState.IsValid)
            {
                db.CustomerContacts.Add(customerContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", customerContact.CustomerID);
            return View(customerContact);
        }

        // GET: CustomerContact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerContact customerContact = db.CustomerContacts.Find(id);
            if (customerContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", customerContact.CustomerID);
            return View(customerContact);
        }

        // POST: CustomerContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerID,Name,Email,ContactNumber")] CustomerContact customerContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", customerContact.CustomerID);
            return View(customerContact);
        }

        // GET: CustomerContact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerContact customerContact = db.CustomerContacts.Find(id);
            if (customerContact == null)
            {
                return HttpNotFound();
            }
            return View(customerContact);
        }

        // POST: CustomerContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerContact customerContact = db.CustomerContacts.Find(id);
            db.CustomerContacts.Remove(customerContact);
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
