using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YFS_MVC.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime DatePaid { get; set; } = DateTime.Now;
        public BillModel Bill { get; set; }
        public decimal Amount { get; set; }
        public RoommateModel roommate { get; set; }
    }
}