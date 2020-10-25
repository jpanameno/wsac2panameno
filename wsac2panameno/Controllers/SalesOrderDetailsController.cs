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
    public class SalesOrderDetailsController : ApiController
    {
        private SalesLTEntities db = new SalesLTEntities();


        // GET: api/SalesOrderDetails/5
        [ResponseType(typeof(SalesOrderDetail))]
        public IHttpActionResult GetOrderTotal(int id)
        {
            var salesOrderDetail = db.SalesOrderDetails.Where(o=>o.SalesOrderID == id).ToList();
            if (salesOrderDetail == null)
            {
                return NotFound();
            }
            decimal total = 0;

            foreach(var item in salesOrderDetail)
            {
                total = total + item.UnitPrice;
            }

            return Json(new
            {
                Total = total
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

        private bool SalesOrderDetailExists(int id)
        {
            return db.SalesOrderDetails.Count(e => e.SalesOrderID == id) > 0;
        }
    }
}