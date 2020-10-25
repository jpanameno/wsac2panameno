using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using wsac2panameno.Models;

namespace wsac2panameno.Controllers
{
    public class ProductsController : ApiController
    {
        private SalesLTEntities db = new SalesLTEntities();

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProductPrice(int id)
        {
            Product product = db.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return Json(new
            {
                Precio = product.ListPrice
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}