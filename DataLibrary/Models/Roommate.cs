using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class Roommate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Bill> Bills { get; set; }
    }
}
