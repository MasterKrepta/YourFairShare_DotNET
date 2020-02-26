using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YFS_MVC.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int RoommateId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DatePaid { get; set; } = DateTime.Now;

        public Payment(int id, int billId, int roommateId, decimal amount, DateTime datePaid)
        {
            this.Id = id;
            this.BillId = billId;
            this.RoommateId = roommateId;
            this.Amount = amount;
            this.DatePaid = datePaid;
        }

        public Payment()
        {

        }
    }
}