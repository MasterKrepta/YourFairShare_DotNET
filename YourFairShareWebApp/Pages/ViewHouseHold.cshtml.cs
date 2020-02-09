using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YFS_DataAccess.DataAcess;
using YFS_DataAccess.Models;

namespace YourFairShareWebApp
{
    
    public class ViewHouseHoldModel : PageModel
    {
        public List<Roommate> Roommates;
        public List<Bill> Bills { get; set; }

        public RoommateContext _db { get; }

        public ViewHouseHoldModel(RoommateContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            GetAllRoommates();
            GetAllBills();
        }

        private void GetAllBills()
        {
            Bills = _db.Bills.ToList();
            
            //TODO reevaluate how bills are stored because we have duplication from our test data
        }

        private void GetAllRoommates()
        {
            Roommates = _db.Roommates.ToList();

        }
    }
}