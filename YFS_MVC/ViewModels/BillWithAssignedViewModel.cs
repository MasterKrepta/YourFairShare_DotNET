using YFS_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YFS_MVC.ViewModels
{
    public class BillWithAssignedViewModel
    {
        public BillModel Bill { get; set; }
        public List<RoommateModel> Roommates { get; set; }
    }
}