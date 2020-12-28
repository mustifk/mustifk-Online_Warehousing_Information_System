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
    }
}