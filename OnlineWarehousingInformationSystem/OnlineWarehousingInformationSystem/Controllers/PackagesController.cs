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
            var query = db.getPackageContents.Where(o => o.packageID == id).ToList();
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
            //PackageContents pc = new PackageContents();
            //pc.packageID = packageID;
            Session["packageID"] = packageID;
            //ViewBag.packageID = packageID;
           // var package = (from pc in db.Packages where pc.packageID == packageID select new { pc.isProvided}).ToList();
           // ViewBag.type = package.FirstOrDefault().isProvided;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(PackageContents pc)
        {
            pc.packageID = Convert.ToInt32(Session["packageID"]);
            /*db.PackageContents.Add(pc);*/
            /*db.Database.ExecuteSqlCommand("INSERT INTO owis.PackageContents(packageID, productID, productQuantity)" +
            "Values('" + pc.packageID + "','" + pc.productID + "','" + pc.productQuantity + "')");*/
            db.PackageContents.Add(pc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult DeleteProducts(int packageID, int productID)
        {
            db.PackageContents.RemoveRange(db.PackageContents.Where(p => p.packageID == packageID).Where(p => p.productID == productID));
            db.SaveChanges();
            return RedirectToAction("DetailPackage", new { id = packageID});
        }

        public ActionResult UpdatePackageProduct(int packageID, int productID)
        {
            var contents = db.PackageContents.Where(p => p.packageID == packageID).Where(p => p.productID == productID).First();
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePackageProduct(PackageContents pc)
        {
            PackageContents u_pc = db.PackageContents.Where(p => p.packageID == pc.packageID).Where(p => p.productID == pc.productID).FirstOrDefault();
            u_pc.productQuantity = pc.productQuantity;
            db.SaveChanges();
            return RedirectToAction("DetailPackage", new { id = pc.packageID });
        }
    }
}