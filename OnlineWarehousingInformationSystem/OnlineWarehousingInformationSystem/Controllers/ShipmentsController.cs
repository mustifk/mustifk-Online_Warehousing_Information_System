using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineWarehousingInformationSystem.Models;
namespace OnlineWarehousingInformationSystem.Controllers
{
    public class ShipmentsController : Controller
    {
        int shipmentID;
        public class MyViewModel
        {
            public List<Shipments> Shipment{ get; set; }
            public List<Packages> Packages{ get; set; }

            public MyViewModel()
            {
                this.Packages = new List<Packages>();
                this.Shipment = new List<Shipments>();
            }
        }
        // GET: Shipments
        OWISDBEntities db = new OWISDBEntities();
        public ActionResult Index()
        {
            var shipments = db.Shipments.Where(o => o.shipmentID > 0).Select(o => o);
            return View(shipments);
        }
        public ActionResult AddShipment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShipment(Shipments shipment)
        {
            shipment.staffID = 1;
            db.Shipments.Add(shipment);
            db.SaveChanges();
            //shipmentID = shipment.shipmentID;
            return RedirectToAction("AddBill", new { shipmentID = shipment.shipmentID });
        }

        public ActionResult AddBill(int shipmentID)
        {
            var bill = new Bills();
            bill.shipmentID = shipmentID;
            return View(bill);
        }

        [HttpPost]
        public ActionResult AddBill(Bills bill)
        {
            //bill.shipmentID = shipmentID;
            db.Bills.Add(bill);
            db.SaveChanges();
            return RedirectToAction("DetailShipment", new { shipmentID = bill.shipmentID});
        }

        public ActionResult DetailShipment(int id)
        {
            MyViewModel query = new MyViewModel();
            query.Shipment = db.Shipments.Where(o => o.shipmentID == id).Select(o => o).ToList();
            query.Packages = db.Packages.Where(o => o.shipmentID == id).Select(o => o).ToList();

            return View(query);
        }

        public ActionResult EditShipment(int id)
        {
            var query = db.Shipments.Find(id);
            return View(query);
        }

        [HttpPost]
        public ActionResult EditShipment(Shipments shipment)
        {
            Shipments u_shipment = db.Shipments.Where(o => o.shipmentID == shipment.shipmentID).FirstOrDefault();
            u_shipment.warehouseID = shipment.warehouseID;
            u_shipment.shipmentDescription = shipment.shipmentDescription;
            u_shipment.shipmentDate = shipment.shipmentDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult DeleteFromShipments(int id)
        {
            db.Shipments.RemoveRange(db.Shipments.Where(o => o.shipmentID == id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}