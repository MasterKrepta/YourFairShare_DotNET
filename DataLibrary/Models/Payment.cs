using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLibrary.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int RoommateId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DatePaid { get; set; } = DateTime.Now;

        public Payment(int id, int billId, int roommateId, decimal amount, DateTime datePaid)
        {
            this.Id = id;
            this.BillId = billId;
            this.RoommateId = roommateId;
            this.AmountPaid = amount;
            this.DatePaid = datePaid;
        }

        public Payment()
        {
            var i = 0;
        }
    }
}