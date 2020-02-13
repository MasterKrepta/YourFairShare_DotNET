using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YFS_MVC.Models;

namespace YFS_MVC.ViewModels
{
    public class HouseHoldViewModel
    {
        
        public List<RoommateModel> Roommates { get; set; }
        public List<BillModel> Bills { get; set; }
    }
}