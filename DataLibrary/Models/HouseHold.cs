using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class HouseHold
    {
        public List<Roommate> Roommates { get; set; }
        public List<Bill> Bills { get; set; }

        public HouseHold()
        {
            Roommates = new List<Roommate>();
            Bills = new List<Bill>();
        }
    }
}
