using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YFS_MVC.Models;

namespace YFS_MVC.ViewModels
{
    public class HouseHoldViewModel
    {

        public List<RoommateModel> Roommates { get; set; } = new List<RoommateModel>();
        public List<BillModel> Bills { get; set; } = new List<BillModel>();
        public PaymentModel Payment { get; set; } = new PaymentModel();
    }
}