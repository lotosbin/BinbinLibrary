using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BinbinJobSearch.Entities;

namespace BinbinJobSearch.WebSite.Controllers
{ 
    public class MerchantController : Controller
    {
        private JobSearchDataContext db = new JobSearchDataContext();

        //
        // GET: /Merchant/

        public ViewResult Index()
        {
            return View(db.Merchant.ToList());
        }

        //
        // GET: /Merchant/Details/5

        public ViewResult Details(int id)
        {
            Merchant merchant = db.Merchant.Find(id);
            return View(merchant);
        }

        //
        // GET: /Merchant/Create

 
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}