using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using suggestionBox.Models;

namespace suggestionBox.Controllers
{
    public class suggestionModelsController : Controller
    {
        private suggestionBoxContext db = new suggestionBoxContext();

        // GET: suggestionModels
        public ActionResult Index()
        {
            return View(db.suggestionModels.ToList());
        }

        // GET: suggestionModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suggestionModel suggestionModel = db.suggestionModels.Find(id);
            if (suggestionModel == null)
            {
                return HttpNotFound();
            }
            return View(suggestionModel);
        }

        // GET: suggestionModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: suggestionModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordNum,Topic,Suggestion,Department")] suggestionModel suggestionModel)
        {
            if (ModelState.IsValid)
            {
                db.suggestionModels.Add(suggestionModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suggestionModel);
        }

        // GET: suggestionModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suggestionModel suggestionModel = db.suggestionModels.Find(id);
            if (suggestionModel == null)
            {
                return HttpNotFound();
            }
            return View(suggestionModel);
        }

        // POST: suggestionModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordNum,Topic,Suggestion,Department")] suggestionModel suggestionModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suggestionModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suggestionModel);
        }

        // GET: suggestionModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            suggestionModel suggestionModel = db.suggestionModels.Find(id);
            if (suggestionModel == null)
            {
                return HttpNotFound();
            }
            return View(suggestionModel);
        }

        // POST: suggestionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            suggestionModel suggestionModel = db.suggestionModels.Find(id);
            db.suggestionModels.Remove(suggestionModel);
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
