using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineWarehousingInformationSystem.Models;
namespace OnlineWarehousingInformationSystem.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        OWISDBEntities db = new OWISDBEntities();
        public ActionResult Index()
        {
            var user = db.Users.Where(s => s.userID > 0).Select(s => s);
            return View(user);
        }
        public ActionResult DetailUser(int id)
        {
            var query = db.Users.Where(s => s.userID == id).Select(s => s);
            return View(query);
        }

        public ActionResult EditUser(int id)
        {
            var query = db.Users.Find(id);
            return View(query);
        }

        [HttpPost]
        public ActionResult EditUser(Users user)
        {
            Users u_user = db.Users.Where(u => u.userID == user.userID).FirstOrDefault();
            u_user.userName = user.userName;
            u_user.userPassword = user.userPassword;
            u_user.firstName = user.firstName;
            u_user.lastName = user.lastName;
            u_user.userType = user.userType;
            u_user.userAddress = user.userAddress;
            u_user.userAge = user.userAge;
            u_user.userGender = user.userGender;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}