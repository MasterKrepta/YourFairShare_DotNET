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
using System.Dynamic;

namespace YFS_MVC.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            var roommateData = LoadRoommates();
            var billData = LoadBills();
            HouseHoldViewModel house = new HouseHoldViewModel();

            foreach (var item in roommateData)
            {
                house.Roommates.Add(new RoommateModel
                {
                    RoommateId = item.RoommateId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    MonthlyPayment = item.MonthlyPayment
                });
            }

            foreach (var item in billData)
            {
                house.Bills.Add(new BillModel
                {
                    BillName = item.BillName,
                    Amount = item.AmountDue,
                    DueDate = item.DueDate,
                    IsCurrent = item.IsCurrent
                });
            }
            return View(house);
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
                                model.LastName,
                                model.MonthlyPayment);
                UpdatePayments(); //TODO dont hard code this 
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
                    RoommateId = item.RoommateId,
                    FirstName = item.FirstName,
                    LastName = item.LastName, 
                    MonthlyPayment = item.MonthlyPayment
                });
            }

            
            //TODO set this up to display both roommates and bills on same page. 
            //HouseHoldViewModel houseHold = new HouseHoldViewModel{
            //    Roommates = roommates,
            //    Bills = bills
            //};

            return View(roommates);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = GetRoommateById(id);
            RoommateModel model = new RoommateModel
            {
                RoommateId = data.RoommateId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                MonthlyPayment = data.MonthlyPayment

            };

            return View(model);
        }

        [HttpPost]
        
        public ActionResult Delete(RoommateModel model)
        {
            //todo why is this not working like the bill delete does?

            //if (ModelState.IsValid)
            //{
                //Todo should be mapping this to datalibrary model
                DeleteRoommate(model.RoommateId);
                UpdatePayments();
                return RedirectToAction("ViewHousehold");
            //}
            return View();
        }

        public ActionResult Edit(int roommateId)
        {
            var data = GetRoommateById(roommateId);
            //Todo should be mapping this to datalibrary model
            RoommateModel r = new RoommateModel
            {
                RoommateId = data.RoommateId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                MonthlyPayment = data.MonthlyPayment
            };

            return View(r);
        }

        [HttpPost]
        public ActionResult Edit(RoommateModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateRoommate(model.RoommateId, model.FirstName, model.LastName);
            }
            return RedirectToAction("ViewHousehold");

        }
    }
}