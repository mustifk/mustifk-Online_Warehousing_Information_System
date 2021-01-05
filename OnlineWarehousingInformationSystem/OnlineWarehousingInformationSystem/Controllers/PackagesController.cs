﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineWarehousingInformationSystem.Models;
namespace OnlineWarehousingInformationSystem.Controllers
{
    public class PackagesController : Controller
    {
        // GET: Packages
        OWISDBEntities db = new OWISDBEntities();
        int pID;
        public ActionResult Index()
        {
            var shipping = db.Packages.Where(o => o.packageID > 0).Select(o => o);
            
            return View(shipping);
        }

        public ActionResult AddPackage(int id, bool type)
        {
            Session["id"] = id.ToString();
            Session["type"] = type.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult AddPackage(Packages package)
        {
            if (Session["type"].Equals("True"))
            {
                package.isProvided = true;
                package.shipmentID = Convert.ToInt32(Session["id"]);
                package.supplierID = 1;
            }
            else
            {
                package.isProvided = false;
                package.orderID = Convert.ToInt32(Session["id"]);
            }
            package.createdTime = DateTime.Now;
            db.Packages.Add(package);
            db.SaveChanges();
            return RedirectToAction("AddShipping", "Shipping", new { id = package.packageID});
        }

        public ActionResult DetailPackage(int id)
        {
            var query = db.PackageContents.Where(o => o.packageID == id).Select(o => o);
            ViewBag.id = id;
            return View(query);
        }

        public ActionResult EditPackage(int id)
        {
            var query = db.Packages.Find(id);
            return View(query);
        }

        [HttpPost]
        public ActionResult EditPackage(Packages package)
        {
            Packages u_package = db.Packages.Where(o => o.packageID == package.packageID).FirstOrDefault();
            u_package.packageStatus = package.packageStatus;
            u_package.supplierID = package.supplierID;
            u_package.notes = package.notes;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult DeleteFromPackages(int id)
        {
            db.Packages.RemoveRange(db.Packages.Where(o => o.packageID == id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddProduct(int packageID)
        {
            //pID = packageID;
            PackageContents pc = new PackageContents();
            //ViewBag.packageID = packageID;
           // var package = (from pc in db.Packages where pc.packageID == packageID select new { pc.isProvided}).ToList();
           // ViewBag.type = package.FirstOrDefault().isProvided;
            return View(pc);
        }
        [HttpPost]
        public ActionResult AddProduct(PackageContents pc)
        {
            //pc.packageID = pID;
            db.PackageContents.Add(pc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}