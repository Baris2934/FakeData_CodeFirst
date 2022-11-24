using FakeData_CodeFirst.Models;
using FakeData_CodeFirst.Models.Context;
using FakeData_CodeFirst.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeData_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homepage()
        {
            MyContext db = new MyContext();
            // List<Kisiler> kisiler = db.Kisiler.ToList();   // Select * from Kisiler

            HomePageVM model = new HomePageVM();
            model.Kisiler = db.Kisiler.ToList();
            model.Adresler = db.Adresler.ToList();
            return View(model);
        }
    }
}