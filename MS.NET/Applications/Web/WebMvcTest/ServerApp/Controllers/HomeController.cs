using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerApp.Controllers
{
    public class HomeController : Controller
    {
        ShopModel model = new ShopModel();

        // GET: Home
        public ActionResult Index()
        {
            return View(model.Products.ToList());
        }

        public ActionResult Details(int id)
        {
            Product product = model.Products.Find(id);
            //explict loading of collection specified by Orders property
            model.Entry(product).Collection(p => p.Orders).Load();
            ViewBag.SelectedProductId = id;
            return View(product.Orders);
        }

        public ActionResult Edit(int id)
        {
            Product product = model.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product input)
        {
            if(ModelState.IsValid)
            {
                model.Entry(input).State = System.Data.Entity.EntityState.Modified;
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(input);
        }
    }
}
