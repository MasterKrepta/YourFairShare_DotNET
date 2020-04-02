using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YFS_MVC.Models
{
    public class RoommateModel
    {
        //[Display(Name ="Roommate ID")]
        //[Range(100000, 999999, ErrorMessage ="You must Enter a valid Id")]
        public int RoommateId { get; set; }
        
        [Required(ErrorMessage ="Enter your first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter your Last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        [DataType(DataType.Currency)]
        public decimal MonthlyPayment { get; set; }
        public bool IsSelected { get; set; }
    }
}