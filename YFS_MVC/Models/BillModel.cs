using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YFS_MVC.Models
{
    public class BillModel
    {
        public int BillId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}