using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLibrary.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime DatePaid { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        //todo how should i store this?
        public List<RoommateModel> RoomatesPaidUp { get; set; }
    }
}