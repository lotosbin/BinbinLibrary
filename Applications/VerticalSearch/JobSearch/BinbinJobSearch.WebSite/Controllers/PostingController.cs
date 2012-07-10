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
    public class PostingController : Controller
    {
        private JobSearchDataContext db = new JobSearchDataContext();

        //
        // GET: /Posting/

        public ViewResult Index()
        {
            var posting = db.Posting.Include(p => p.Merchant);
            return View(posting.ToList());
        }

        //
        // GET: /Posting/Details/5

        public ViewResult Details(int id)
        {
            Posting posting = db.Posting.Find(id);
            return View(posting);
        }

        //
        // GET: /Posting/Create

 
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}