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
        public class MyViewModel
        {
            public List<Orders> Order { get; set; }
            public List<Packages> Packages { get; set; }

            public MyViewModel()
            {
                this.Packages = new List<Packages>();
                this.Order = new List<Orders>();
            }
        }
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
            MyViewModel query = new MyViewModel();
            query.Order = db.Orders.Where(o => o.orderID == id).Select(o => o).ToList();
            query.Packages = db.Packages.Where(o => o.orderID == id).Select(o => o).ToList();
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
    }
}