using DataLibrary.BusinessLogic;
using System.Collections.Generic;
using System.Web.Mvc;
using YFS_MVC.ViewModels;
using YFS_MVC.Models;
using System;
using System.Globalization;

namespace YFS_MVC.Controllers
{
	

	public class PaymentController : Controller
	{

		

		// GET: Payment
		public ActionResult Index()
		{
			return View();
		}
	
		public ActionResult ListUnpaidBills()
		{

			var data = PaymentProcessor.GetUnpaidBills();
			List<AssignedBillViewModel> assignedBills = new List<AssignedBillViewModel>();

			foreach (var p in data)
			{

				assignedBills.Add(new AssignedBillViewModel
				{
					BillName = p.BillName,
					FirstName = p.FirstName,
					LastName = p.LastName,
					AmountDue = p.AmountDue,
					DueDate = p.DueDate
				});
			   
			}
			return View(assignedBills);
		}

		public ActionResult ListPaidBills()
		{
			List<AssignedBillViewModel> model = new List<AssignedBillViewModel>();
			var paymentData = PaymentProcessor.GetPaidBills();
			foreach (var p in paymentData)
			{
				model.Add(new AssignedBillViewModel
				{
					BillName = p.BillName,
					FirstName = p.FirstName,
					LastName = p.LastName,
					AmountDue = p.AmountDue,
					DueDate = p.DueDate
				});
			}

			return View(model);
		}

		public ActionResult AddPayment(int? roommateId, int? billId, decimal? amountOwed)
		{
			

			if (roommateId != null && billId !=null)
			{
				
				ViewBag.selectedRoommate = RoommateProcessor.GetRoommateById((int)roommateId).FullName; 
				ViewBag.selectedBill = BillProcessor.GetBillById((int)billId).BillName;
				ViewBag.AmountOwed = amountOwed?.ToString("C", CultureInfo.CurrentCulture);
			}
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

		
		public ActionResult Details(int id)
		{
			PaymentModel model = new PaymentModel();
			//Todo should be mapping this to datalibrary model
			var data = PaymentProcessor.GetPaymentById(id);
			//todo change this to display payment details via View model
			model = new PaymentModel
			{
				Id = data.Id,
				RoommateId = data.RoommateId,
				BillId = data.BillId,
				AmountPaid = data.AmountPaid,
				DatePaid = data.DatePaid
			};
			return View(model);
		}

	   
	}
}