using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YFS_MVC.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime DatePaid { get; set; }
        public decimal Amount { get; set; }
        public List<RoommateModel> RoomatesPaidUp { get; set; }
    }
}