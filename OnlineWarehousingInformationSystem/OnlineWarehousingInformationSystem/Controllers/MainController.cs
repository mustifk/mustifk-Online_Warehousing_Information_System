using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineWarehousingInformationSystem.Models;

namespace OnlineWarehousingInformationSystem.Controllers
{
    public class MainController : Controller
    {
        OWISDBEntities db = new OWISDBEntities();
        // GET: Main
        public ActionResult Index()
        {
            var userId = (int)Session["UserId"];
            return View(db.Users.Where(s => s.userID == userId).ToList());
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}