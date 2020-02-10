using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace YourFairShareWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        HouseHold _household;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _household = new HouseHold();
        }

        

        public void OnGet()
        {
            var test = SqlDataAccess.GetCnnString();

            test += 5;

            
            //LoadSampleData();
        }

        private void LoadSampleData()
        {
            if (_household.Roommates.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("testData.json");
                var roommate = JsonSerializer.Deserialize<List<Roommate>>(file);
                SqlDataAccess.SaveData("spSaveSampleData", roommate);
            }

        }
    }
}
