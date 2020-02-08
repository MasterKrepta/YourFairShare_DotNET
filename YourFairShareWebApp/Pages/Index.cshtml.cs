using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using YFS_DataAccess.DataAcess;
using YFS_DataAccess.Models;

namespace YourFairShareWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public RoommateContext _db { get; }

        public IndexModel(ILogger<IndexModel> logger, RoommateContext db)
        {
            _logger = logger;
            _db = db;
        }

        

        public void OnGet()
        {
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            if (_db.Roommates.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("testData.json");
                var roommate = JsonSerializer.Deserialize<List<Roommate>>(file);
                _db.AddRange(roommate);
                _db.SaveChanges();
            }

        }
    }
}
