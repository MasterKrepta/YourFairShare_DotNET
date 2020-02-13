using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.DataAccess;
using static DataLibrary.BusinessLogic.RoommateProcessor;
using static DataLibrary.BusinessLogic.BillProcessor;
using YFS_MVC.ViewModels;
using YFS_MVC.Models;

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




        public ActionResult ViewHousehold()
        {
            var roommateData = LoadRoommates();
            List<RoommateModel> roommates = new List<RoommateModel>();

            foreach (var item in roommateData)
            {
                roommates.Add(new RoommateModel
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName
                });
            }

            
            //TODO set this up to display both roommates and bills on same page. 
            //HouseHoldViewModel houseHold = new HouseHoldViewModel{
            //    Roommates = roommates,
            //    Bills = bills
            //};

            return View(roommates);
        }

    }
}