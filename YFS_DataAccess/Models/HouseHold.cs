using System;
using System.Collections.Generic;
using System.Text;

namespace YFS_DataAccess.Models
{
    public class HouseHold
    {
        public int Id { get; set; }
        public List<Roommate> Roommates { get; set; }
        public List<Bill> Bills { get; set; }
    }
}
