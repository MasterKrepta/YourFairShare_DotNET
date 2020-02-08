using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YFS_DataAccess.Models
{
    public class Bill
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        
        public decimal Amount { get; set; }
        public string DueDate { get; set; }
    }
}
