using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YFS_MVC.Models
{
    public class BillModel
    {
        public int ID { get; set; }
        
        public string BillName { get; set; }

        
        public decimal Amount { get; set; }

        
        public DateTime DueDate { get; set; }

        public bool IsCurrent { get; set; }

        public List<RoommateModel> Roommates { get; set; } = new List<RoommateModel>();

    }
}