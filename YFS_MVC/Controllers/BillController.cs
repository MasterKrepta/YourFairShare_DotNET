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
                    BillName = item.BillName,
                    Amount = item.AmountDue,
                    DueDate = item.DueDate
                });
            }
            return View(bills);
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
                                model.BillName,
                                model.Amount,
                                model.DueDate);
                return RedirectToAction("ViewBills");
            }

            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(string name)
        {
            var data = GetBill(name);
            BillModel model = new BillModel
            {
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
                DeleteBill(model.BillName, model.Amount, model.DueDate);
                UpdatePayments(model.Amount);
                return RedirectToAction("ViewBills");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string BillName)
        {
            var data = GetBill(BillName);
            //Todo should be mapping this to datalibrary model
            BillModel b = new BillModel
            {
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