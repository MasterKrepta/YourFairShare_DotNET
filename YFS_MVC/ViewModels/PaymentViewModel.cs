﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YFS_MVC.Models;
using DataLibrary.BusinessLogic;

namespace YFS_MVC.ViewModels
{
	public class PaymentViewModel
	{
		public decimal AmountDue
		{
			get
			{
				var data = BillProcessor.GetBillById(Payment.BillId);
				return data.AmountDue;
			}
		}
		public PaymentModel Payment;

		private string _roommate;

		public string Roommate
		{
			get 
			{
				var data = RoommateProcessor.GetRoommateById(Payment.RoommateId);
				_roommate = data.FullName;
				return _roommate; 
			}
		
		}

		private string _bill;

		public string Bill
		{
			get
			{
				var data = BillProcessor.GetBillById(Payment.BillId);
				_bill = data.BillName;
				return _bill; 
			}
		}

	}
	
}