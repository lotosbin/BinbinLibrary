using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Binbin.Product.MvcApplicationMain.Entities;
using Binbin.Product.MvcApplicationMain.Models;
namespace Binbin.Product.MvcApplicationMain.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            using (var context = new ProductEntities())
            {

                var products = (from p in context.ProductSet
                                select new ProductListModel()
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Description = p.Description,
                                    Author = p.Author,
                                    AddTime = p.AddTime,
                                    UpdateTime = p.UpdateTime,
                                }).ToList();
                return View(products);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductCreateModel model)
        {
            if (this.ModelState.IsValid)
            {
                using (var context = new ProductEntities())
                {
                    var product = new Entities.Product()
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Author = this.User.Identity.Name,
                        AddTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                    };
                    context.ProductSet.AddObject(product);
                    context.SaveChanges();
                }
                return this.RedirectToAction("Index");
            }
            return View();
        }
    }
}
