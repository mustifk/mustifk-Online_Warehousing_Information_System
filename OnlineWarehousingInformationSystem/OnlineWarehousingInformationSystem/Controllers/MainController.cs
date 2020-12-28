﻿using System;
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
        public ActionResult Index()
        {
            var rec = new List<Tuple<int,string,string>>
            {
                new Tuple<int,string,string>(db.Users.Count(),"User" , "Users"),
                new Tuple<int,string,string>(db.Warehouses.Count(),"Warehouse" , "Warehouses"),
                new Tuple<int,string,string>(db.Products.Count(),"Product" , "Products"),
                new Tuple<int,string,string>(db.Suppliers.Count(),"Supplier" , "Suppliers"),
                new Tuple<int,string,string>(db.Packages.Count(),"Package" , "Packages"),
                new Tuple<int,string,string>(db.Shipping.Count(),"Shipping" , "Shipping"),
            };
            ViewData["rec"] = rec;
            return View(ViewData);
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Tracking(int search = -1)
        {
            var package = db.Packages.Where(x => x.packageID == search || search == null).ToList();
            if (package.Count == 0 && search != -1)
            {
                ViewData["non"] = true;
                return View(package);
            }
            ViewData["non"] = false;
            return View(package);
        }
    }
}