using System;
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
        public ActionResult Index()
        {
            var shipping = db.Packages.Where(o => o.packageID > 0).Select(o => o);
            
            return View(shipping);
        }

        public ActionResult AddPackage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPackage(Packages package)
        {
            db.Packages.Add(package);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            u_package.createdTime = package.createdTime;
            u_package.packageStatus = package.packageStatus;
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

        public ActionResult UpdateQuantity(int id)
        {
            var query = db.PackageContents.Where(p => p.productID == id).FirstOrDefault();
            return View();
        }

    }
}