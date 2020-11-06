using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerApp.Controllers
{
    public class ProductsController : ApiController
    {
        ShopModel model = new ShopModel();

        public IEnumerable<Product> Get()
        {
            return model.Products.ToList();
        }

        public IHttpActionResult Get(int id)
        {
            Product product = model.Products.Find(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        public IHttpActionResult Put(Product input)
        {
            Product product = model.Products.Find(input.Id);

            if (product == null)
                return NotFound();

            try
            {
                product.Price = input.Price;
                product.Stock = input.Stock;
                model.SaveChanges();
                return Ok();
            }
            catch(DbEntityValidationException)
            {
                return BadRequest(ModelState);
            }


        }
    }
}
