using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace YFS_MVC.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }
        [Display(Name ="Bill")]
        public int BillId { get; set; }
        [Display(Name = "Roommate")]
        public int RoommateId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DatePaid { get; set; } = DateTime.Now;

        public PaymentModel(int id, int billId, int roommateId, decimal amountPaid, DateTime datePaid)
        {
            this.Id = id;
            this.BillId = billId;
            this.RoommateId = roommateId;
            this.AmountPaid = amountPaid;
            this.DatePaid = datePaid;
        }

        public PaymentModel()
        {

        }
    }
}