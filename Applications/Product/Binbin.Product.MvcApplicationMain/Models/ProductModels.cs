using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binbin.Product.MvcApplicationMain.Models
{
    public class ProductModels
    {
    }
    public class ProductListModel
    {

        public ProductListModel()
        {

        }
        public ProductListModel(Entities.Product p)
        {
            this.Id = p.Id;
            this.Name = p.Name;
            this.Description = p.Description;
            this.Author = p.Author;
            this.AddTime = p.AddTime;
            this.UpdateTime = p.UpdateTime;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
    public class ProductCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}