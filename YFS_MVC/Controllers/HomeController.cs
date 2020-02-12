using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YFS_MVC.Models;
using DataLibrary;
using static DataLibrary.BusinessLogic.RoommateProcessor;

namespace YFS_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Join()
        {
            ViewBag.Message = "Join This Household.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Join(RoommateModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateRoommate(
                                model.FirstName, 
                                model.LastName);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}