using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BinbinJobFeed.Entities;

namespace BinbinJobFeed.WebSite.Controllers
{
    public class PostingFeedController : Controller
    {
        private BinbinJobFeedDataContext db = new BinbinJobFeedDataContext();
        //
        // GET: /PostingFeed/

        public ActionResult Index()
        {
            return View(db.Posting.ToList());
        }

    }
}
