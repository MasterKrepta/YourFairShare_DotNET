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

        List<BillModel> Bills = new List<BillModel>();
        List<RoommateModel> Roommates = new List<RoommateModel>();
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

        public ActionResult AddBill()
        {
            ViewBag.Message = "Add A New Bill";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBill(BillModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateBill(
                                model.Name,
                                model.Amount,
                                model.DueDate);
                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult ViewHousehold()
        {

            var test = SqlDataAccess.LoadData<List<RoommateModel>>("sp_GetAllRoommates");
            
            //var roommates = SqlDataAccess.LoadData<List<RoommateModel>>("select * from Roommates where FirstName = 'Gina'").ToList();
            var bills = SqlDataAccess.LoadData<List<BillModel>>("sp_GetAllBills");
            return View(test);
        }

    }
}