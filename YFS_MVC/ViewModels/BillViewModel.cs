using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YFS_MVC.Models;

namespace YFS_MVC.ViewModels
{
    public class BillViewModel
    {
        public List<BillModel> Bills { get; set; }
        public List<RoommateModel> Roommates { get; set; }
        // get bill
        //sort name by who paid what
        //create list of who owes what. 


    }
}