using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class BillModel
    {
        public int ID { get; set; }
        public string BillName { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCurrent { get; set; }
        public List<RoommateModel> Roommates { get; set; } = new List<RoommateModel>();

 
    }
}
