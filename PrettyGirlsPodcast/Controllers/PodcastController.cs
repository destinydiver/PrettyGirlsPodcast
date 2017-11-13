using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrettyGirlsPodcast.DAL;
using PrettyGirlsPodcast.Models;

namespace PrettyGirlsPodcast.Controllers
{
    public class PodcastController : Controller
    {
        private DB db = new DB();

        // GET: Podcast
        public ActionResult Index()
        {
            return View(db.Podcasts.ToList());
        }

        // GET: Podcast/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podcast podcast = db.Podcasts.Find(id);
            if (podcast == null)
            {
                return HttpNotFound();
            }
            return View(podcast);
        }

        // GET: Podcast/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Podcast/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Podcast_Id,Title,DateCasted,Description")] Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                db.Podcasts.Add(podcast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(podcast);
        }

        // GET: Podcast/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podcast podcast = db.Podcasts.Find(id);
            if (podcast == null)
            {
                return HttpNotFound();
            }
            return View(podcast);
        }

        // POST: Podcast/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Podcast_Id,Title,DateCasted,Description")] Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(podcast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(podcast);
        }

        // GET: Podcast/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podcast podcast = db.Podcasts.Find(id);
            if (podcast == null)
            {
                return HttpNotFound();
            }
            return View(podcast);
        }

        // POST: Podcast/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Podcast podcast = db.Podcasts.Find(id);
            db.Podcasts.Remove(podcast);
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
