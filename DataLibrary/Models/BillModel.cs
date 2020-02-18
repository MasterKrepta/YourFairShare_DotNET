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
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
    }
}
