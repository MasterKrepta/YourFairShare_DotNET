using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace YourFairShareWebApp
{
    
    public class ViewHouseHoldModel : PageModel
    {
        public List<Roommate> Roommates;
        public List<Bill> Bills { get; set; }

        public void OnGet()
        {
            GetAllRoommates();
            GetAllBills();
        }

        private void GetAllBills()
        {
            var data = SqlDataAccess.LoadData<Bill>("spGetAllBills");
            
            //TODO reevaluate how bills are stored because we have duplication from our test data
        }

        private void GetAllRoommates()
        {
            //Roommates = _db.Roommates.ToList();

        }
    }
}