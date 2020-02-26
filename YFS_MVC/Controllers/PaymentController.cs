using DataLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YFS_MVC.ViewModels;
using DataLibrary.BusinessLogic;
using YFS_MVC.Models;

namespace YFS_MVC.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }


        
        public ActionResult ListPayments()
        {

            var data = PaymentProcessor.LoadPayments();
            List<PaymentViewModel> payments = new List<PaymentViewModel>();

            foreach (var p in data)
            {
                payments.Add(new PaymentViewModel
                {
                    Payment = new Payment(p.Id, p.BillId, p.RoommateId, p.AmountPaid, p.DatePaid)
                   
                }); ; 
               
            }
            return View(payments);
        }

        public ActionResult AddPayment()
        {
            HouseHoldViewModel model = new HouseHoldViewModel();
            var billData = BillProcessor.LoadBills();
            var roommateData = RoommateProcessor.LoadRoommates();
            foreach (var item in billData)
            {
                model.Bills.Add(new Models.BillModel { 
                    ID = item.ID,
                    BillName = item.BillName,
                    Amount = item.AmountDue,
                    DueDate = item.DueDate
                });
            }
            foreach (var item in roommateData)
            {
                model.Roommates.Add(new Models.RoommateModel
                {
                    RoommateId = item.RoommateId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    MonthlyPayment = item.MonthlyPayment
                });
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPayment(HouseHoldViewModel model)
        {
            if (ModelState.IsValid)
            {
                PaymentProcessor.CreatePayment(
                                model.Payment.BillId,
                                model.Payment.RoommateId,
                                model.Payment.AmountPaid);

                //todo get bill and roommate from 


                return RedirectToAction("Index");
            }

            return View();
        }


    }
}