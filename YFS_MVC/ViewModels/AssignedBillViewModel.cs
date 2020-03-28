using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YFS_MVC.ViewModels
{
    public class AssignedBillViewModel
    {
        public int RoommateId { get; set; }
        public int BillId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BillName { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime DueDate { get; set; }
    }
}