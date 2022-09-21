using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskApi.Models;

namespace TaskApi.Controllers
{
    public class QuotesController : Controller
    {
        private TaskContext db = new TaskContext();

        // GET: Quotes
        public ActionResult Index()
        {
            var quotes = new List<QuoteViewModel>();
            foreach (var q in db.Quotes)
            {
                quotes.Add(new QuoteViewModel(q));
            }

            return View(quotes);
        }

        // GET: Quotes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // GET: Quotes/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.Personnels, "Id", "Role");
            ViewBag.QuoteTypeId = new SelectList(db.QuoteTypes, "Id", "Name");
            ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "Id", "Name");
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QuoteTypeId,TaskTypeId,TaskDescription,ContactId,DueDate")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Quotes.Add(quote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.Personnels, "Id", "Role", quote.ContactId);
            ViewBag.QuoteTypeId = new SelectList(db.QuoteTypes, "Id", "Name", quote.QuoteTypeId);
            ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "Id", "Name", quote.TaskTypeId);
            return View(quote);
        }

        // GET: Quotes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Personnels, "Id", "Role", quote.ContactId);
            ViewBag.QuoteTypeId = new SelectList(db.QuoteTypes, "Id", "Name", quote.QuoteTypeId);
            ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "Id", "Name", quote.TaskTypeId);
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QuoteTypeId,TaskTypeId,TaskDescription,ContactId,DueDate")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Personnels, "Id", "Role", quote.ContactId);
            ViewBag.QuoteTypeId = new SelectList(db.QuoteTypes, "Id", "Name", quote.QuoteTypeId);
            ViewBag.TaskTypeId = new SelectList(db.TaskTypes, "Id", "Name", quote.TaskTypeId);
            return View(quote);
        }

        // GET: Quotes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Quote quote = db.Quotes.Find(id);
            db.Quotes.Remove(quote);
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
