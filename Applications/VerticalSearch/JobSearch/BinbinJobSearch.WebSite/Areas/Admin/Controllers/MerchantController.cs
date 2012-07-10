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
    public class MerchantController : Controller
    {
        private JobSearchDataContext db = new JobSearchDataContext();

        //
        // GET: /Admin/Merchant/

        public ViewResult Index()
        {
            return View(db.Merchant.ToList());
        }

        //
        // GET: /Admin/Merchant/Details/5

        public ViewResult Details(int id)
        {
            Merchant merchant = db.Merchant.Find(id);
            return View(merchant);
        }

        //
        // GET: /Admin/Merchant/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Merchant/Create

        [HttpPost]
        public ActionResult Create(Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                db.Merchant.Add(merchant);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(merchant);
        }
        
        //
        // GET: /Admin/Merchant/Edit/5
 
        public ActionResult Edit(int id)
        {
            Merchant merchant = db.Merchant.Find(id);
            return View(merchant);
        }

        //
        // POST: /Admin/Merchant/Edit/5

        [HttpPost]
        public ActionResult Edit(Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(merchant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(merchant);
        }

        //
        // GET: /Admin/Merchant/Delete/5
 
        public ActionResult Delete(int id)
        {
            Merchant merchant = db.Merchant.Find(id);
            return View(merchant);
        }

        //
        // POST: /Admin/Merchant/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Merchant merchant = db.Merchant.Find(id);
            db.Merchant.Remove(merchant);
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