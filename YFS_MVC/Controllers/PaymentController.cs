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
					Payment = new PaymentModel(p.Id, p.BillId, p.RoommateId, p.AmountPaid, p.DatePaid)
				   
				}); ; 
			   
			}
			return View(payments);
		}

		public ActionResult AddPayment(int? roommateId, int? billId)
		{
			if (roommateId != null && billId !=null)
			{
				
				ViewBag.selectedRoommate = RoommateProcessor.GetRoommateById((int)roommateId).FullName; 
				ViewBag.selectedBill = BillProcessor.GetBillById((int)billId).BillName;
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

	   public ActionResult WhoPaidWhat()
		{
			List<PaymentViewModel> model = new List<PaymentViewModel>();
			var paymentData = PaymentProcessor.GetBillsByWithPayers();
			foreach (var p in paymentData)
			{
				model.Add(new PaymentViewModel
				{
					Payment = new PaymentModel(p.Id, p.BillId, p.RoommateId, p.AmountPaid, p.DatePaid)

				}); ;
			}
		
			
	
			return View(model);
		}
	}
}