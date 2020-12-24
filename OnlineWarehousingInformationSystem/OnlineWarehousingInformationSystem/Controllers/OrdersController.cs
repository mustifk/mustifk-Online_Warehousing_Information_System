using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineWarehousingInformationSystem.Models;
namespace OnlineWarehousingInformationSystem.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        OWISDBEntities db = new OWISDBEntities();
        public ActionResult Index()
        {
            var orders = db.Orders.Where(o => o.orderID > 0).Select(o => o);
            return View(orders);
        }
        public ActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrder(Orders order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailOrder(int id)
        {
            var query = db.Orders.Where(o => o.warehouseID == id).Select(o => o);
            return View(query);
        }

        public ActionResult EditOrder(int id)
        {
            var query = db.Orders.Find(id);
            return View(query);
        }

        [HttpPost]
        public ActionResult EditOrder(Orders order)
        {
            Orders u_order = db.Orders.Where(o => o.orderID == order.orderID).FirstOrDefault();
            u_order.warehouseID = order.warehouseID;
            u_order.orderDescription = order.orderDescription;
            u_order.orderDate = order.orderDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult DeleteFromOrders(int id)
        {
            db.Orders.RemoveRange(db.Orders.Where(o => o.orderID == id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowPayments(int id)
        {
            var query = db.Payments.Where(p => p.orderID == id).Select(p => p);
            return View(query);
        }
    }
}