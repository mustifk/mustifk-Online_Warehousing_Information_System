using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OnlineWarehousingInformationSystem.Models;

namespace OnlineWarehousingInformationSystem.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        OWISDBEntities db = new OWISDBEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                OWISDBEntities db = new OWISDBEntities();
                var user = (from userlist in db.Users
                            where userlist.userName == login.UserName && userlist.userPassword == login.Password
                            select new
                            {
                                userlist.userID,
                                userlist.userName,
                                userlist.userType
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["UserName"] = user.FirstOrDefault().userName;
                    Session["UserID"] = user.FirstOrDefault().userID;
                    Session["UserType"] = user.FirstOrDefault().userType;
                    return Redirect("/Main/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "The user name or password is incorrect");
                }
            }
            return View(login);
        }
        public ActionResult Updateuser(int id)
        {
            var st = db.Users.Find(id);
            return View(st);
        }

        [HttpPost]
        public ActionResult Updateuser(Users user)
        {
            Users updateduser = db.Users.Where(s => s.userID == user.userID).FirstOrDefault();
            updateduser.userName = user.userName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {

            Session.Clear();
            return Redirect("Login");
        }
    }
}