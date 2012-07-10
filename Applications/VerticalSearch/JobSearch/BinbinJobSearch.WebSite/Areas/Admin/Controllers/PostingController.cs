using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BinbinJobSearch.Entities;

namespace BinbinJobSearch.WebSite.Areas.Admin.Controllers
{ 
    public class PostingController : Controller
    {
        private JobSearchDataContext db = new JobSearchDataContext();

        //
        // GET: /Admin/Posting/

        public ViewResult Index()
        {
            var posting = db.Posting.Include(p => p.Merchant);
            return View(posting.ToList());
        }

        //
        // GET: /Admin/Posting/Details/5

        public ViewResult Details(int id)
        {
            Posting posting = db.Posting.Find(id);
            return View(posting);
        }

        //
        // GET: /Admin/Posting/Create

        public ActionResult Create()
        {
            ViewBag.MerchantID = new SelectList(db.Merchant, "MerchantID", "Name");
            return View();
        } 

        //
        // POST: /Admin/Posting/Create

        [HttpPost]
        public ActionResult Create(Posting posting)
        {
            if (ModelState.IsValid)
            {
                db.Posting.Add(posting);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.MerchantID = new SelectList(db.Merchant, "MerchantID", "Name", posting.MerchantID);
            return View(posting);
        }
        
        //
        // GET: /Admin/Posting/Edit/5
 
        public ActionResult Edit(int id)
        {
            Posting posting = db.Posting.Find(id);
            ViewBag.MerchantID = new SelectList(db.Merchant, "MerchantID", "Name", posting.MerchantID);
            return View(posting);
        }

        //
        // POST: /Admin/Posting/Edit/5

        [HttpPost]
        public ActionResult Edit(Posting posting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MerchantID = new SelectList(db.Merchant, "MerchantID", "Name", posting.MerchantID);
            return View(posting);
        }

        //
        // GET: /Admin/Posting/Delete/5
 
        public ActionResult Delete(int id)
        {
            Posting posting = db.Posting.Find(id);
            return View(posting);
        }

        //
        // POST: /Admin/Posting/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Posting posting = db.Posting.Find(id);
            db.Posting.Remove(posting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}