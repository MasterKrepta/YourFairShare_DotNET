using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YFS_MVC.Models;
using static DataLibrary.BusinessLogic.BillProcessor;

namespace YFS_MVC.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewBills()
        {
            var billData = LoadBills();
            List<BillModel> bills = new List<BillModel>();
            foreach (var item in billData)
            {
                bills.Add(new BillModel
                {
                    ID = item.ID,
                    BillName = item.BillName,
                    Amount = item.AmountDue,
                    DueDate = item.DueDate, 
                    IsCurrent = item.IsCurrent
                });
            }
            return View(bills);
        }
        public ActionResult AddBill()
        {
            ViewBag.Message = "Add A New Bill";
            var data = DataLibrary.BusinessLogic.RoommateProcessor.LoadRoommates();
            var newBill = new BillModel();
            foreach (var item in data)
            {
                newBill.Roommates.Add(new RoommateModel{
                    RoommateId = item.RoommateId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    MonthlyPayment = item.MonthlyPayment
                });
            }
            

            return View(newBill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBill(BillModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateBill(
                                model.BillName,
                                model.Amount,
                                model.DueDate);
                //TODO assign bills here based  on the checkboxes
                //todo currently assigned to every tennat
                return RedirectToAction("ViewBills");
            }

            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = GetBillById(id);
            BillModel model = new BillModel
            {
                ID = id,
                BillName = data.BillName,
                Amount = data.AmountDue,
                DueDate = data.DueDate

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(BillModel model)
        {
            if (ModelState.IsValid)
            {
                DeleteBill(model.ID);
                UpdatePayments(model.Amount);
                return RedirectToAction("ViewBills");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = GetBillById(id);
            //Todo should be mapping this to datalibrary model
            BillModel b = new BillModel
            {
                ID = data.ID,
                BillName = data.BillName,
                Amount = data.AmountDue,
                DueDate = data.DueDate
            };

            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(BillModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateBill(model.BillName, model.Amount, model.DueDate);
            }
            return RedirectToAction("ViewBills");

        }
    }
}