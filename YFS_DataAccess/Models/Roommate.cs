using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YFS_DataAccess.Models
{
    public class Roommate
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string LastName  { get; set; }


        public List<Bill> AssignedBills { get; set; }
    }
}
