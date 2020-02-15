﻿using System;
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
                    Name = item.Name,
                    Amount = item.Amount,
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
                                model.Name,
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
                Name = data[0].Name,
                Amount = data[0].Amount,
                DueDate = data[0].DueDate

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(BillModel model)
        {
            if (ModelState.IsValid)
            {
                DeleteBill(model.Name, model.Amount, model.DueDate);
                UpdatePayments(model.Amount);
                return RedirectToAction("ViewBills");
            }
            return View();
        }

    }
}