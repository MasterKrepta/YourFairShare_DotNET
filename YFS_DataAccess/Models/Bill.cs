using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YFS_DataAccess.Models
{
    public class Bill
    {
        //TODO make uniqe bills via id
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Amount { get; set; }
        public string DueDate { get; set; }

    }
}
