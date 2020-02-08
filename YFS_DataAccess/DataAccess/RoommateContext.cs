using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YFS_DataAccess.Models;

namespace YFS_DataAccess.DataAcess
{
    public class RoommateContext :DbContext
    {
        public RoommateContext(DbContextOptions options): base(options){}

        public DbSet<Roommate> Roommates { get; set; }
        public DbSet<Bill> Bills { get; set; }

    }
}
